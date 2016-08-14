using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.WebConnection;

namespace Willo.Logic.Login
{
    public class AuthorizeCommand : ICommand
    {
        public AuthorizationToken AuthorizationToken { get; }

        public AuthorizeCommand(AuthorizationToken authorizationToken)
        {
            this.AuthorizationToken = authorizationToken;
        }
    }
}
