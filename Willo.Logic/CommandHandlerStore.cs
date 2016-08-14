using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic
{
    public class CommandHandlerStore : ICommandHandlerStore
    {
        private Dictionary<Type, ICommandHandler> store = new Dictionary<Type, ICommandHandler>();

        public void Register<TCommand>(ICommandHandler<TCommand> handler)
            where TCommand : ICommand
        {
            var queryType = typeof(TCommand);
            store.Add(queryType, handler);
        }

        public void Unregister<TCommand>(ICommandHandler<TCommand> handler)
            where TCommand : ICommand
        {
            var queryType = typeof(TCommand);
            store.Remove(queryType);
        }

        public ICommandHandler Get(ICommand query)
        {
            var handler = store[query.GetType()];
            return handler;
        }
    }
}
