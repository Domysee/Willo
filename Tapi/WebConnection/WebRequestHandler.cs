using System;
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
            var uri = new Uri(url);
            using (var client = createClient(applicationKey, authorizationToken))
            {
                var response = await getResponse(client, uri);
                if (!response.IsSuccessStatusCode)
                    throw new RequestFailedException(url);

                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }

        private async Task<HttpResponseMessage> getResponse(HttpClient client, Uri uri)
        {
            try
            {
                var response = await client.GetAsync(uri);
                return response;
            }
            catch (Exception)
            {
                throw new NetworkException();
            }
        }
    }
}
