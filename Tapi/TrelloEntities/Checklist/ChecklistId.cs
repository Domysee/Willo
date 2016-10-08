using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Checklist
{
    public struct ChecklistId
    {
        private string id;

        public ChecklistId(string id)
        {
            checkId(id);
            this.id = id;
        }

        public static implicit operator ChecklistId(string id)
        {
            return new ChecklistId(id);
        }

        public static implicit operator string(ChecklistId id)
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
