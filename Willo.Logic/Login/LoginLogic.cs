using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi;
using Tapi.Authorization;
using Tapi.WebConnection;

namespace Willo.Logic.Login
{
    public class LoginLogic
    {
        private Trello api;

        public LoginLogic(Trello api)
        {
            this.api = api;
        }

        public void Authorize(AuthorizationToken token)
        {
            api.Authorize(TrelloData.AppplicationKey, token);
        }
    }
}
