using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.TrelloEntities.Member;

namespace Tapi.TrelloEntities.Action
{
    /// <summary>
    /// represents a subset of the data of the member who did the action
    /// </summary>
    public class ActionExecutor
    {
        public MemberId Id { get; private set; }
        public string Username { get; private set; }
        public string FullName { get; private set; }
        public string Initials { get; private set; }
        public object AvatarHash { get; private set; }
    }
}
