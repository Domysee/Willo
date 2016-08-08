using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.TrelloEntities.Board;
using Willo.Logic;

namespace Willo.View.Components.BoardOverview
{
    public class BoardOverviewViewModel
    {
        private BoardOverviewLogic logic;
        public IReadOnlyCollection<Board> Boards { get; private set; }

        public BoardOverviewViewModel(BoardOverviewLogic logic)
        {
            this.logic = logic;
        }

        public async Task Initialize()
        {
            Boards = (await logic.GetBoards()).ToList();
        }
    }
}
