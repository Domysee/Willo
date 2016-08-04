using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tapi.WebConnection
{
    public struct AuthorizationToken
    {
        private string token;

        public AuthorizationToken(string token)
        {
            checkToken(token);
            this.token = token;
        }

        public static implicit operator AuthorizationToken(string token)
        {
            return new AuthorizationToken(token);
        }

        public static implicit operator string(AuthorizationToken token)
        {
            return token.token;
        }

        private static void checkToken(string token)
        {
            if (token.Length != 64)
                throw new ArgumentException("A Trello authorization token must be 64 characters");

            var allowedCharacters = new Regex("^[0-9a-z]*$");
            if (!allowedCharacters.IsMatch(token))
                throw new ArgumentException("A Trello authorization token must only contain alphanumeric, lowercase characters");
        }

        public override string ToString()
        {
            return token;
        }
    }
}
