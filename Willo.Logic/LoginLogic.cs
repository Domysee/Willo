using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi;
using Tapi.Authorization;
using Tapi.WebConnection;

namespace Willo.Logic
{
    public class LoginLogic
    {
        private Trello api;

        public LoginLogic(Trello api)
        {
            this.api = api;
        }

        public string GetAuthenticationUrl()
        {
            return Tapi.Authorization.Authorize.GetAuthorizationUrl(TrelloData.AppplicationKey, TrelloData.ApplicationName, AuthorizationScope.ReadWriteAccount, AuthorizationExpiration.Never);
        }

        public bool IsAuthorizationToken(string token)
        {
            try
            {
                new AuthorizationToken(token);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Authorize(AuthorizationToken token)
        {
            api.Authorize(TrelloData.AppplicationKey, token);
        }
    }
}
