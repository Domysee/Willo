using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.List
{
    public struct ListId
    {
        private string id;

        public ListId(string id)
        {
            checkId(id);
            this.id = id;
        }

        public static implicit operator ListId(string id)
        {
            return new ListId(id);
        }

        public static implicit operator string(ListId id)
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
