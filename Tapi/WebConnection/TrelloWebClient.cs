using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.Authorization;

namespace Tapi.WebConnection
{
    public class TrelloWebClient : ITrelloWebClient
    {
        private const string AuthorizationTestUrl = "https://api.trello.com/1/members/me";
        private IWebRequestHandler webRequestHandler;
        public bool IsAuthorized { get; private set; }
        private ApplicationKey applicationKey;
        private AuthorizationToken authorizationToken;

        public TrelloWebClient()
        {
            webRequestHandler = new WebRequestHandler();
        }

        public TrelloWebClient(IWebRequestHandler webRequestHandler)
        {
            this.webRequestHandler = webRequestHandler;
        }

        public async Task<bool> CheckAuthorizationParameters(ApplicationKey applicationKey, AuthorizationToken authorizationToken)
        {
            try
            {
                var response = await webRequestHandler.Get(AuthorizationTestUrl, applicationKey, authorizationToken);
                return true;
            }
            catch (AuthorizationDeniedException)
            {
                return false;
            }
        }

        public async Task Authorize(ApplicationKey applicationKey, AuthorizationToken authorizationToken)
        {
            var authorizationParametersCorrect = await CheckAuthorizationParameters(applicationKey, authorizationToken);
            if (!authorizationParametersCorrect)
                throw new AuthorizationDeniedException(applicationKey, authorizationToken);

            this.applicationKey = applicationKey;
            this.authorizationToken = authorizationToken;
            this.IsAuthorized = true;
        }

        private void checkAuthorization()
        {
            if (!IsAuthorized) throw new UnauthorizedException();
        }

        public async Task<JToken> Get(string url)
        {
            checkAuthorization();
            var uri = new UriBuilder(url);
            var response = await webRequestHandler.Get(url, applicationKey, authorizationToken);
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
