using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.WebConnection;
using Willo.Logic.Errors;

namespace Willo.Logic.Infrastructure
{
    public abstract class TrelloQueryHandlerBase<TQuery, TReturn> : QueryHandlerBase<TQuery, TReturn>
        where TQuery : IQuery<TReturn>
    {
        public override async Task<QueryResult<TReturn>> Handle(TQuery query)
        {
            try
            {
                return await handleImplementation(query);
            }
            catch (AuthorizationDeniedException)
            {
                var error = new AuthorizationDeniedError();
                return QueryResult<TReturn>.CreateFailure(new[] { error });
            }
            catch (RequestFailedException)
            {
                var error = new RequestFailedError();
                return QueryResult<TReturn>.CreateFailure(new[] { error });
            }
        }

        protected abstract Task<QueryResult<TReturn>> handleImplementation(TQuery query);
    }
}
