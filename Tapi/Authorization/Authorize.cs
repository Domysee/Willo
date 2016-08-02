using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.Authorization
{
    public class Authorize
    {
        private const string AuthorizationUrl = "https://trello.com/1/authorize";

        /// <summary>
        /// creates a url that can be used to authorize the application
        /// </summary>
        /// <param name="applicationKey">your Trello api key</param>
        /// <param name="applicationName">the name of the application you want to authorize</param>
        /// <param name="scope">the rights the application should have</param>
        /// <param name="expiration">how long the optained token should be valid, use AuthorizationExpiration</param>
        /// <returns></returns>
        public string GetAuthorizationUrl(ApplicationKey applicationKey, string applicationName, AuthorizationScope scope, string expiration)
        {
            return $"{AuthorizationUrl}?key={applicationKey}&name={applicationName}&scope={scope}&expiration={expiration}";
        }
    }
}
