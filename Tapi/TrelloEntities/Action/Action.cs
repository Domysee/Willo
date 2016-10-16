using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.TrelloEntities.Member;

namespace Tapi.TrelloEntities.Action
{
    public abstract class Action
    {
        public ActionId Id { get; private set; }
        public MemberId CreatorId { get; private set; }
        public DateTime Date { get; private set; }
        public ActionOwner Executor { get; private set; }
    }
}
