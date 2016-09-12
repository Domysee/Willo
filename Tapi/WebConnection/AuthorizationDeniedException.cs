using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.Authorization;

namespace Tapi.WebConnection
{
    public class AuthorizationDeniedException : Exception
    {
        public AuthorizationDeniedException(ApplicationKey applicationKey, AuthorizationToken authorizationToken) :
            base($"The server did not accept the token {authorizationToken} and application key {applicationKey} for authorization")
        { }

        public AuthorizationDeniedException() :
           base($"The server did not accept the given token and application key for authorization")
        { }
    }
}
