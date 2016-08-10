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

namespace Tapi.WebConnection
{
    public class TrelloWebClient : ITrelloWebClient
    {
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
            var client = new HttpClient(httpBaseFilter);
            return client;
        }

        private void appendAuthorizationParameter(UriBuilder uri)
        {
            var authorization = $"key={applicationKey}&token={authorizationToken}";
            if (String.IsNullOrWhiteSpace(uri.Query))
                uri.Query = authorization;
            else
                uri.Query += $"&{authorization}";
        }

        private void throwIfNotAuthorized()
        {
            if (!IsAuthorized) throw new UnauthorizedException();
        }

        public async Task<JToken> Get(string url)
        {
            throwIfNotAuthorized(); 
            var uri = new UriBuilder(url);
            appendAuthorizationParameter(uri);
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
