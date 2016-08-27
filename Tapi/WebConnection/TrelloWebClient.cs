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

        private const string InvalidTokenResponse = "invalid token";
        private const string AuthorizationTestUrl = "https://api.trello.com/1/members/me";
        private IWebRequestHandler webRequestHandler;
        public bool IsAuthorized { get; private set; }
        private ApplicationKey applicationKey;
        private AuthorizationToken authorizationToken;

        public TrelloWebClient()
        {
            webRequestHandler = new WebRequestHandler();
        }

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
            var response = await webRequestHandler.Get(AuthorizationTestUrl, applicationKey, authorizationToken);
            return response != InvalidTokenResponse;
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
            var response = await webRequestHandler.Get(url, applicationKey, authorizationToken);
            if (response == InvalidTokenResponse)
                throw new AuthorizationDeniedException(applicationKey, authorizationToken);

            var result = await Task.Run(() => JToken.Parse(response));
            return result;
        }

        public async Task<T> Get<T>(string url) where T : JToken
        {
            var result = await Get(url);
            return (T)result;
        }
    }
}
