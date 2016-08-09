using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi;
using Tapi.TrelloEntities;
using Tapi.TrelloEntities.Board;

namespace Willo.Logic.BoardOverview
{
    public class BoardOverviewLogic
    {
        private Trello api;

        public BoardOverviewLogic(Trello api)
        {
            this.api = api;
        }

        public async Task<IEnumerable<OverviewBoard>> GetBoards()
        {
            var boards = await api.Boards.GetAll(MemberId.AuthorizedUser);
            return boards.Select(b => new OverviewBoard(b.Id, b.Name));
        }
    }
}
