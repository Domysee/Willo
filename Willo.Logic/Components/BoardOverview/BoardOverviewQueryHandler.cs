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
    public class BoardOverviewQueryHandler : TrelloQueryHandlerBase<BoardOverviewQuery, IEnumerable<BoardOverview>>
    {
        private ITrello api;

        public BoardOverviewQueryHandler(ITrello api)
        {
            this.api = api;
        }

        protected override async Task<QueryResult<IEnumerable<BoardOverview>>> handleImplementation(BoardOverviewQuery query)
        {
            var propertiesToLoad = new BoardOverviewQueryParameters
            {
                Fields = new BoardFields { Name = true }
            };
            var boards = await api.Boards.GetAll(MemberId.AuthorizedUser, propertiesToLoad);
            var boardOverviews = boards.Select(b => new BoardOverview(b.Id, b.Name));
            return QueryResult<IEnumerable<BoardOverview>>.CreateSuccess(boardOverviews);
        }
    }
}
