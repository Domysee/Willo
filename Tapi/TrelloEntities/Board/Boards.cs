using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.WebConnection;

namespace Tapi.TrelloEntities.Board
{
    public class Boards : IBoards
    {
        private ITrelloWebClient webClient;

        public Boards(ITrelloWebClient webClient)
        {
            this.webClient = webClient;
        }

        public async Task<IEnumerable<Board>> GetAll(MemberId memberId, BoardOverviewQueryParameters queryParameters = null)
        {
            if (memberId == null) throw new ArgumentNullException("The given memberId is null. To use the authorized user, use MemberId.AuthorizedUser");

            var url = $"{ConnectionData.BaseUrl}/members/{memberId}/boards";
            if (queryParameters != null)
                url += "?" + queryParameters.ToQueryString();
            var result = await webClient.Get<JArray>(url);
            var boards = result.Select(json => Board.FromJson((JObject)json)).ToList();
            return boards;
        }

        public async Task<Board> Get(string boardId)
        {
            if (boardId == null) throw new ArgumentNullException(nameof(boardId));

            var url = $"{ConnectionData.BaseUrl}/boards/{boardId}";
            var result = await webClient.Get<JObject>(url);
            var board = Board.FromJson(result);
            return board;
        }
    }
}
