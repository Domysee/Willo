using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Action
{
    public class Action
    {
        public string Id { get; private set; }
        public MemberId CreatorId { get; private set; }
        public string Type { get; private set; }
        public object Data { get; private set; }
    }
}
