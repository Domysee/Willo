using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.TrelloEntities.Member;

namespace Tapi.TrelloEntities.Board
{
    public class Membership
    {
        public string Id { get; private set; }
        public MemberId MemberId { get; private set; }
        public MemberType MemberType { get; private set; }
        public bool IsUnconfirmed { get; private set; }
        public bool IsDeactivated { get; private set; }
    }
}
