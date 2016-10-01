using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.TrelloEntities.Board;
using Willo.Logic;
using Willo.Logic.Components.BoardOverview;
using Willo.View.Infrastructure;
using Willo.Logic.Infrastructure;

namespace Willo.View.Components.BoardOverview
{
    public class BoardOverviewViewModel : BindableBase
    {
        private IMessageBroker messageBroker;
        private IReadOnlyCollection<Logic.Components.BoardOverview.BoardOverview> boards;
        public IReadOnlyCollection<Logic.Components.BoardOverview.BoardOverview> Boards
        {
            get { return boards; }
            set { SetProperty(ref boards, value); }
        }

        public BoardOverviewViewModel(IMessageBroker messageBroker)
        {
            this.messageBroker = messageBroker;
        }

        public async Task Initialize()
        {
            var queryResult = await messageBroker.Query(new BoardOverviewQuery());
            Boards = queryResult.Result.ToList();
        }
    }
}
