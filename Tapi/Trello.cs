using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.Authorization;
using Tapi.TrelloEntities.Board;
using Tapi.WebConnection;

namespace Tapi
{
    /// <summary>
    /// Trello is the entry point for users of the api
    /// </summary>
    public class Trello
    {
        private ITrelloWebClient webClient;

        public Boards Boards { get; }

        public Trello()
        {
            webClient = new TrelloWebClient();
            Boards = new Boards(webClient);
        }

        public void Authorize(ApplicationKey applicationKey, AuthorizationToken authorizationToken)
        {
            webClient.Authorize(applicationKey, authorizationToken);
        }
    }
}
