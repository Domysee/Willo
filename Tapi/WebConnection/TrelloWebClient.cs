using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Tapi.WebConnection
{
    public class TrelloWebClient
    {
        private AuthorizationToken authorizationToken;

        public void Authorize(AuthorizationToken authorizationToken)
        {
            this.authorizationToken = authorizationToken;
        }

        public async Task<T> Get<T>(string url)
        {
            var uri = new Uri(url, UriKind.Absolute);
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var responseJson = await response.Content.ReadAsStringAsync();
                var result = await Task.Run(() => JsonConvert.DeserializeObject<T>(responseJson));
                return result;
            }
        }
    }
}
