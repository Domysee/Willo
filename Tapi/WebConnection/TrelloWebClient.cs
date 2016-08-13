using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.Authorization;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using Windows.Web.Http.Headers;
using Windows.Foundation;

namespace Tapi.WebConnection
{
    public class TrelloWebClient : ITrelloWebClient
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

        public bool IsAuthorized { get; private set; }
        private ApplicationKey applicationKey;
        private AuthorizationToken authorizationToken;

        public void Authorize(ApplicationKey applicationKey, AuthorizationToken authorizationToken)
        {
            this.applicationKey = applicationKey;
            this.authorizationToken = authorizationToken;
            this.IsAuthorized = true;
        }

        private HttpClient createClient()
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

        private void checkAuthorization()
        {
            if (!IsAuthorized) throw new UnauthorizedException();
        }

        public async Task<JToken> Get(string url)
        {
            checkAuthorization();
            var uri = new UriBuilder(url);
            using (var client = createClient())
            {
                var response = await client.GetAsync(uri.Uri);
                var responseJson = await response.Content.ReadAsStringAsync();
                var result = await Task.Run(() => JToken.Parse(responseJson));
                return result;
            }
        }

        public async Task<T> Get<T>(string url) where T : JToken
        {
            var result = await Get(url);
            return (T)result;
        }
    }
}
