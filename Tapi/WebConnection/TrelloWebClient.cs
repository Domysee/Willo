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

        private const string InvalidTokenResponse = "invalid token";
        private const string AuthorizationTestUrl = "https://api.trello.com/1/members/me";
        public bool IsAuthorized { get; private set; }
        private ApplicationKey applicationKey;
        private AuthorizationToken authorizationToken;

        /// <summary>
        /// authorizes the client
        /// </summary>
        /// <param name="applicationKey"></param>
        /// <param name="authorizationToken"></param>
        /// <returns></returns>
        /// <exception cref="AuthorizationDeniedException">Occurs if the authorization parameters are not accepted by the server</exception>
        public async Task Authorize(ApplicationKey applicationKey, AuthorizationToken authorizationToken)
        {
            if (!await CheckAuthorizationParameters(applicationKey, authorizationToken))
                throw new AuthorizationDeniedException(applicationKey, authorizationToken);

            this.applicationKey = applicationKey;
            this.authorizationToken = authorizationToken;
            this.IsAuthorized = true;
        }

        /// <summary>
        /// Checks if the server accepts the authorization parameters
        /// </summary>
        /// <param name="applicationKey"></param>
        /// <param name="authorizationToken"></param>
        /// <returns></returns>
        public async Task<bool> CheckAuthorizationParameters(ApplicationKey applicationKey, AuthorizationToken authorizationToken)
        {
            using (var client = createClient(applicationKey, authorizationToken))
            {
                var response = await client.GetAsync(new Uri(AuthorizationTestUrl));
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString != InvalidTokenResponse;
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

        private void checkAuthorization()
        {
            if (!IsAuthorized) throw new UnauthorizedException();
        }

        /// <summary>
        /// returns the content of the given url, using the authorization
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <exception cref="AuthorizationDeniedException">Occurs if the user revoked the authorization token</exception>
        public async Task<JToken> Get(string url)
        {
            checkAuthorization();
            var uri = new UriBuilder(url);
            using (var client = createClient(applicationKey, authorizationToken))
            {
                var response = await client.GetAsync(uri.Uri);
                var responseJson = await response.Content.ReadAsStringAsync();
                if (responseJson == InvalidTokenResponse)
                    throw new AuthorizationDeniedException(applicationKey, authorizationToken);
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
