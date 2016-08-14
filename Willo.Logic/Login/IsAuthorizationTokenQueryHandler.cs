using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.WebConnection;

namespace Willo.Logic.Login
{
    public class IsAuthorizationTokenQueryHandler : QueryHandlerBase<IsAuthorizationTokenQuery, bool>
    {
        public override bool Handle(IsAuthorizationTokenQuery query)
        {
            try
            {
                new AuthorizationToken(query.AuthorizationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
