using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic.Infrastructure
{
    public class MessageBroker : IMessageBroker
    {
        private IQueryHandlerStore queryHandlerStore;
        private ICommandHandlerStore commandHandlerStore;

        public MessageBroker(IQueryHandlerStore queryHandlerStore, ICommandHandlerStore commandHandlerStore)
        {
            this.queryHandlerStore = queryHandlerStore;
            this.commandHandlerStore = commandHandlerStore;
        }

        public void RegisterHandler<TQuery, TReturn>(IQueryHandler<TQuery, TReturn> handler)
            where TQuery : IQuery<TReturn>
        {
            queryHandlerStore.Register(handler);
        }

        public void UnregisterHandler<TQuery, TReturn>(IQueryHandler<TQuery, TReturn> handler)
            where TQuery : IQuery<TReturn>
        {
            queryHandlerStore.Unregister(handler);
        }

        public void RegisterHandler<TCommand>(ICommandHandler<TCommand> handler)
            where TCommand : ICommand
        {
            commandHandlerStore.Register(handler);
        }

        public void UnregisterHandler<TCommand>(ICommandHandler<TCommand> handler)
            where TCommand : ICommand
        {
            commandHandlerStore.Unregister(handler);
        }

        public async Task<T> Query<T>(IQuery<T> query)
        {
            var handler = queryHandlerStore.Get(query);
            //the cast is guaranteed to work, because registering a query handler uses the concrete query type, and also checks the return type, which is set in the query interface
            //getting the handler also uses the concrete query type
            return (T)await handler.Handle(query);
        }

        public async Task<IEnumerable<IError>> Command(ICommand command)
        {
            var handler = commandHandlerStore.Get(command);
            return await handler.Handle(command);
        }
    }
}
