using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic
{
    public abstract class QueryHandlerBase<TQuery, TReturn> : IQueryHandler<TQuery, TReturn>
        where TQuery : IQuery<TReturn>
    {
        public async Task<object> Handle(IQuery query)
        {
            if (!(query is TQuery))
                throw new ArgumentException("The query type doesn't match");
            return await Handle((TQuery)query);
        }

        public abstract Task<TReturn> Handle(TQuery query);
    }
}
