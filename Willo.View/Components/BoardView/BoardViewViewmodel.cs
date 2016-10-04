using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willo.Logic.Infrastructure;
using Willo.View.Infrastructure;

namespace Willo.View.Components.BoardView
{
    public class BoardViewViewmodel : BindableBase
    {
        private IMessageBroker messageBroker;

        public BoardViewViewmodel(IMessageBroker messageBroker)
        {
            this.messageBroker = messageBroker;
        }

        public async Task Initialize()
        {

        }
    }
}
