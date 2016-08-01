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
        public const string ReadOnly = "read";
        public const string ReadWrite = "read,write";
        public const string ReadOnlyAccount = "read,account";
        public const string ReadWriteAccount = "read,write,account";
    }
}
