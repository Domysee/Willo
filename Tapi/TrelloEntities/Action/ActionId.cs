using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Action
{
    public struct ActionId
    {
        private string id;

        public ActionId(string id)
        {
            checkId(id);
            this.id = id;
        }

        public static implicit operator ActionId(string id)
        {
            return new ActionId(id);
        }

        public static implicit operator string(ActionId id)
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
