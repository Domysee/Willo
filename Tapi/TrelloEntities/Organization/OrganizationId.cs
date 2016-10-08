using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Organization
{
    public struct OrganizationId
    {
        private string id;

        public OrganizationId(string id)
        {
            checkId(id);
            this.id = id;
        }

        public static implicit operator OrganizationId(string id)
        {
            return new OrganizationId(id);
        }

        public static implicit operator string(OrganizationId id)
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
