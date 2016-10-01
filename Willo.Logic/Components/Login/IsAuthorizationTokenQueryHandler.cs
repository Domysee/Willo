using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.WebConnection;
using Willo.Logic.Infrastructure;

namespace Willo.Logic.Components.Login
{
    public class IsAuthorizationTokenQueryHandler : QueryHandlerBase<IsAuthorizationTokenQuery, bool>
    {
        public override async Task<QueryResult<bool>> Handle(IsAuthorizationTokenQuery query)
        {
            bool isAuthorizationToken;
            try
            {
                new AuthorizationToken(query.AuthorizationToken);
                isAuthorizationToken = true;
            }
            catch (Exception)
            {
                isAuthorizationToken = false;
            }
            return QueryResult<bool>.CreateSuccess(isAuthorizationToken);
        }
    }
}
