using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic
{
    public class QueryHandlerStore : IQueryHandlerStore
    {
        private Dictionary<Type, IQueryHandler> store = new Dictionary<Type, IQueryHandler>();

        public void Register<TQuery, TReturn>(IQueryHandler<TQuery, TReturn> handler)
            where TQuery : IQuery<TReturn>
        {
            var queryType = typeof(TQuery);
            store.Add(queryType, handler);
        }

        public void Unregister<TQuery, TReturn>(IQueryHandler<TQuery, TReturn> handler)
            where TQuery : IQuery<TReturn>
        {
            var queryType = typeof(TQuery);
            store.Remove(queryType);
        }

        public IQueryHandler Get(IQuery query)
        {
            var handler = store[query.GetType()];
            return handler;
        }
    }
}
