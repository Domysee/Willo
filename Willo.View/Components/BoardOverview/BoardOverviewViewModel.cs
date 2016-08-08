using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.TrelloEntities.Board;
using Willo.Logic;
using Willo.View.Infrastructure;

namespace Willo.View.Components.BoardOverview
{
    public class BoardOverviewViewModel : BindableBase
    {
        private BoardOverviewLogic logic;
        private IReadOnlyCollection<Board> boards;
        public IReadOnlyCollection<Board> Boards
        {
            get { return boards; }
            set { SetProperty(ref boards, value); }
        }

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
