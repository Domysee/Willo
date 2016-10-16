using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tapi.TrelloEntities.Card;

namespace Tapi.TrelloEntities.Action
{
    public class ActionAssociatedCard
    {
        public CardId Id { get; private set; }
        public int ShortId { get; private set; }
        public string Name { get; private set; }
        public string ShortLink { get; private set; }
    }
}
