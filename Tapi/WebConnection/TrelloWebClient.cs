using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.WebConnection
{
    public class TrelloWebClient
    {
        private AuthorizationToken authorizationToken;

        public void Authorize(AuthorizationToken authorizationToken)
        {
            this.authorizationToken = authorizationToken;
        }
    }
}
