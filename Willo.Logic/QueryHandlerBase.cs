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
        public object Handle(IQuery query)
        {
            if (!(query is TQuery))
                throw new ArgumentException("The query type doesn't match");
            return Handle((TQuery)query);
        }

        public abstract TReturn Handle(TQuery query);
    }
}
