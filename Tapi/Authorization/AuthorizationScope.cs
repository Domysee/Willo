using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.Authorization
{
    /// <summary>
    /// read and write are self-explanatory
    /// account includes writing of member info and marking notifications as read
    /// as described here: https://developers.trello.com/authorize
    /// </summary>
    public class AuthorizationScope
    {
        public static readonly AuthorizationScope ReadOnly = new AuthorizationScope("read");
        public static readonly AuthorizationScope ReadWrite = new AuthorizationScope("read,write");
        public static readonly AuthorizationScope ReadOnlyAccount = new AuthorizationScope("read,account");
        public static readonly AuthorizationScope ReadWriteAccount = new AuthorizationScope("read,write,account");

        private string scope;

        private AuthorizationScope(string scope)
        {
            this.scope = scope;
        }

        public static explicit operator string(AuthorizationScope scope)
        {
            return scope.scope;
        }
    }
}
