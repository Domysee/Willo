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
    public class Trello : ITrello
    {
        private ITrelloWebClient webClient;

        public IBoards Boards { get; }

        public Trello()
        {
            webClient = new TrelloWebClient();
            Boards = new Boards(webClient);
        }

        /// <summary>
        /// Authorizes the api client with the given application key and authorization token
        /// </summary>
        /// <param name="applicationKey"></param>
        /// <param name="authorizationToken"></param>
        /// <exception cref="AuthorizationDeniedException">Occurs if the authorization parameters are not accepted by the server</exception>
        public async Task Authorize(ApplicationKey applicationKey, AuthorizationToken authorizationToken)
        {
            await webClient.Authorize(applicationKey, authorizationToken);
        }
    }
}
