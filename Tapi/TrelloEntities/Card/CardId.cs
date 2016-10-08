using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Card
{
    public struct CardId
    {
        private string id;

        public CardId(string id)
        {
            checkId(id);
            this.id = id;
        }

        public static implicit operator CardId(string id)
        {
            return new CardId(id);
        }

        public static implicit operator string(CardId id)
        {
            return id.id;
        }

        private static void checkId(string id)
        {

        }

        public override string ToString()
        {
            return id;
        }
    }
}
