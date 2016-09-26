using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willo.Logic.Infrastructure;

namespace Willo.Logic.Components.Login
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
