using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic
{
    public class MessageBroker : IMessageBroker
    {
        private IQueryHandlerStore queryHandlerStore;

        public MessageBroker(IQueryHandlerStore queryHandlerStore)
        {
            this.queryHandlerStore = queryHandlerStore;
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

        public T Query<T>(IQuery<T> query)
        {
            var handler = queryHandlerStore.Get(query);
            //the cast is guaranteed to work, because registering a query handler uses the concrete query type, and also checks the return type, which is set in the query interface
            //getting the handler also uses the concrete query type
            return (T)handler.Handle(query);
        }
    }
}
