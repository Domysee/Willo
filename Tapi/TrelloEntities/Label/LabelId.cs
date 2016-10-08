using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Label
{
    public struct LabelId
    {
        private string id;

        public LabelId(string id)
        {
            checkId(id);
            this.id = id;
        }

        public static implicit operator LabelId(string id)
        {
            return new LabelId(id);
        }

        public static implicit operator string(LabelId id)
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
