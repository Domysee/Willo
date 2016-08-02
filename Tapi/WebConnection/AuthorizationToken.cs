using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.WebConnection
{
    public struct AuthorizationToken
    {
        private string token;

        public AuthorizationToken(string token)
        {
            this.token = token;
        }

        public static implicit operator AuthorizationToken(string token)
        {
            return new AuthorizationToken(token);
        }

        public static explicit operator string(AuthorizationToken token)
        {
            return token.token;
        }
    }
}
