using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic.Infrastructure
{
    public interface IQueryHandler
    {
        Task<object> Handle(IQuery query);
    }

    public interface IQueryHandler<TQuery, TReturn> : IQueryHandler
        where TQuery : IQuery<TReturn>
    {
        Task<QueryResult<TReturn>> Handle(TQuery query);
    }
}
