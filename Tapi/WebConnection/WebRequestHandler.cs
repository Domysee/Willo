﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.Authorization;
using System.Net.Http;
using System.Threading;

namespace Tapi.WebConnection
{
    public class WebRequestHandler : IWebRequestHandler
    {
        private class AddCredentialsHandler : MessageProcessingHandler
        {
            private ApplicationKey applicationKey;
            private AuthorizationToken authorizationToken;

            public AddCredentialsHandler(ApplicationKey applicationKey, AuthorizationToken authorizationToken)
            {
                this.applicationKey = applicationKey;
                this.authorizationToken = authorizationToken;
                this.InnerHandler = new HttpClientHandler();
            }

            protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var builder = new UriBuilder(request.RequestUri);
                var authorization = $"key={applicationKey}&token={authorizationToken}";
                if (String.IsNullOrWhiteSpace(builder.Query))
                    builder.Query = authorization;
                else
                    builder.Query = builder.Query.Remove(0, 1) + $"&{authorization}";   //remove the questionmark at the beginning
                request.RequestUri = builder.Uri;
                return request;
            }

            protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
            {
                return response;
            }
        }

        private HttpClient createClient(ApplicationKey applicationKey, AuthorizationToken authorizationToken)
        {
            var client = new HttpClient(new AddCredentialsHandler(applicationKey, authorizationToken), true);
            return client;
        }

        public async Task<string> Get(string url, ApplicationKey applicationKey, AuthorizationToken authorizationToken)
        {
            Uri uri;
            try
            {
                uri = new Uri(url);
            }
            catch (Exception)
            {
                throw new ArgumentException("The given url is not valid");
            }

            using (var client = createClient(applicationKey, authorizationToken))
            {
                var response = await client.GetAsync(uri);
                if (!response.IsSuccessStatusCode)
                    throw new RequestFailedException(url);

                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }
    }
}
