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
            if (handler == null) throw new ArgumentNullException("The given handler is null");

            var queryType = typeof(TCommand);
            store.Add(queryType, handler);
        }

        public void Unregister<TCommand>(ICommandHandler<TCommand> handler)
            where TCommand : ICommand
        {
            if (handler == null) throw new ArgumentNullException("The given handler is null");

            var queryType = typeof(TCommand);
            store.Remove(queryType);
        }

        public ICommandHandler Get(ICommand query)
        {
            if (store.ContainsKey(query.GetType()))
                return store[query.GetType()];
            else
                return null;
        }
    }
}
