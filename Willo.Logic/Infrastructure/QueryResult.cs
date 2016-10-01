using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic.Infrastructure
{
    public class QueryResult<TResult>
    {
        public TResult Result { get; private set; }
        public ResultState State { get; private set; }
        public IEnumerable<IError> Errors { get; private set; }

        private QueryResult() { }

        public static QueryResult<TResult> Create(TResult result, IEnumerable<IError> errors)
        {
            if (errors == null || errors.Count() == 0)
                return QueryResult<TResult>.CreateSuccess(result);
            else
                return QueryResult<TResult>.CreateFailure(errors);
        }

        public static QueryResult<TResult> CreateSuccess(TResult result)
        {
            return new QueryResult<TResult>
            {
                Result = result,
                State = ResultState.Success,
                Errors = Enumerable.Empty<IError>()
            };
        }

        public static QueryResult<TResult> CreateFailure(IEnumerable<IError> errors)
        {
            return new QueryResult<TResult>
            {
                Result = default(TResult),
                State = ResultState.Failure,
                Errors = errors
            };
        }
    }
}
