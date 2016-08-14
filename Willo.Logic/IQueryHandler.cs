using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic
{
    public interface IQueryHandler
    {
        object Handle(IQuery query);
    }

    public interface IQueryHandler<TQuery, TReturn> : IQueryHandler
        where TQuery : IQuery<TReturn>
    {
        TReturn Handle(TQuery query);
    }
}
