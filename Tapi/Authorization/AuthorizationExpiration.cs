using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.Authorization
{
    public class AuthorizationExpiration
    {
        public static readonly AuthorizationExpiration OneHour = new AuthorizationExpiration("1hour");
        public static readonly AuthorizationExpiration OneDay = new AuthorizationExpiration("1day");
        public static readonly AuthorizationExpiration ThirtyDays = new AuthorizationExpiration("30days");
        public static readonly AuthorizationExpiration Never = new AuthorizationExpiration("never");

        private string expiration;

        private AuthorizationExpiration(string expiration)
        {
            this.expiration = expiration;
        }

        public static explicit operator string(AuthorizationExpiration expiration)
        {
            return expiration.expiration;
        }
    }
}
