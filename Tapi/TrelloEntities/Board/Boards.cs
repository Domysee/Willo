using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.WebConnection;

namespace Tapi.TrelloEntities.Board
{
    public class Boards
    {
        private TrelloWebClient webClient;

        public Boards(TrelloWebClient webClient)
        {
            this.webClient = webClient;
        }

        /// <summary>
        /// gets all boards of the given user
        /// </summary>
        /// <param name="memberId">the user to get the boards from</param>
        /// <param name="properties">the properties that should be returned by the api</param>
        /// <returns></returns>
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
