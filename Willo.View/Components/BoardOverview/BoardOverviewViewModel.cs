﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.TrelloEntities.Board;
using Willo.Logic;
using Willo.Logic.Components.BoardOverview;
using Willo.View.Infrastructure;

namespace Willo.View.Components.BoardOverview
{
    public class BoardOverviewViewModel : BindableBase
    {
        private MessageBroker messageBroker;
        private IReadOnlyCollection<Logic.Components.BoardOverview.BoardOverview> boards;
        public IReadOnlyCollection<Logic.Components.BoardOverview.BoardOverview> Boards
        {
            get { return boards; }
            set { SetProperty(ref boards, value); }
        }

        public BoardOverviewViewModel(MessageBroker messageBroker)
        {
            this.messageBroker = messageBroker;
        }

        public async Task Initialize()
        {
            Boards = (await messageBroker.Query(new BoardOverviewQuery())).ToList();
        }
    }
}
