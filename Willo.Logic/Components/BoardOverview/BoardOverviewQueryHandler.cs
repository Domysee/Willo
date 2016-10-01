using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi;
using Tapi.TrelloEntities;
using Tapi.TrelloEntities.Board;
using Willo.Logic.Infrastructure;

namespace Willo.Logic.Components.BoardOverview
{
    public class BoardOverviewQueryHandler : QueryHandlerBase<BoardOverviewQuery, IEnumerable<BoardOverview>>
    {
        private ITrello api;

        public BoardOverviewQueryHandler(ITrello api)
        {
            this.api = api;
        }

        public override async Task<QueryResult<IEnumerable<BoardOverview>>> Handle(BoardOverviewQuery query)
        {
            var propertiesToLoad = new BoardProperties { Name = true };
            var boards = await api.Boards.GetAll(MemberId.AuthorizedUser, propertiesToLoad);
            var boardOverviews = boards.Select(b => new BoardOverview(b.Id, b.Name));
            return QueryResult<IEnumerable<BoardOverview>>.CreateSuccess(boardOverviews);
        }
    }
}
