using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic.Login
{
    public class IsAuthorizationTokenQuery: IQuery<bool>
    {
        public string AuthorizationToken { get; }

        public IsAuthorizationTokenQuery(string authorizationToken)
        {
            this.AuthorizationToken = authorizationToken;
        }
    }
}
