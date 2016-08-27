using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Web.Http;
using System.Text;
using System.Threading.Tasks;
using Tapi.Authorization;
using Windows.Web.Http.Filters;
using Windows.Foundation;

namespace Tapi.WebConnection
{
    public class WebRequestHandler : IWebRequestHandler
    {
        private class AddCredentialsFilter : IHttpFilter
        {
            private ApplicationKey applicationKey;
            private AuthorizationToken authorizationToken;
            private IHttpFilter next;

            public AddCredentialsFilter(ApplicationKey applicationKey, AuthorizationToken authorizationToken, IHttpFilter next)
            {
                this.applicationKey = applicationKey;
                this.authorizationToken = authorizationToken;
                this.next = next;
            }

            public IAsyncOperationWithProgress<HttpResponseMessage, HttpProgress> SendRequestAsync(HttpRequestMessage request)
            {
                var builder = new UriBuilder(request.RequestUri);
                var authorization = $"key={applicationKey}&token={authorizationToken}";
                if (String.IsNullOrWhiteSpace(builder.Query))
                    builder.Query = authorization;
                else
                    builder.Query = builder.Query.Remove(0, 1) + $"&{authorization}";   //remove the questionmark at the beginning
                request.RequestUri = builder.Uri;
                return next.SendRequestAsync(request);
            }

            public void Dispose()
            {
            }
        }

        private HttpClient createClient(ApplicationKey applicationKey, AuthorizationToken authorizationToken)
        {
            //this is needed to disallow the HttpClient asking for credentials in a GUI
            //as described here: http://stackoverflow.com/a/24410237/3107430
            var httpBaseFilter = new HttpBaseProtocolFilter
            {
                AllowUI = false
            };
            var addCredentialsFilter = new AddCredentialsFilter(applicationKey, authorizationToken, httpBaseFilter);
            var client = new HttpClient(addCredentialsFilter);
            return client;
        }

        public async Task<string> Get(string url, ApplicationKey applicationKey, AuthorizationToken authorizationToken)
        {
            var uri = new UriBuilder(url);
            using (var client = createClient(applicationKey, authorizationToken))
            {
                var response = await client.GetAsync(uri.Uri);
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }
    }
}
