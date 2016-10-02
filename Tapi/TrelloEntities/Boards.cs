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

        public async Task<IEnumerable<Board>> GetAll(MemberId memberId, BoardProperties properties = null)
        {
            if (memberId == null) throw new ArgumentNullException("The given memberId is null. To use the authorized user, use MemberId.AuthorizedUser");

            var url = $"{ConnectionData.BaseUrl}/members/{memberId}/boards";
            if (properties != null)
                url += "?fields=" + properties.ToString();
            var result = await webClient.Get<JArray>(url);
            var boards = result.Select(json => Board.FromJson((JObject)json)).ToList();
            return boards;
        }
    }
}
