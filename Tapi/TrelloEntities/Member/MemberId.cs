using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Member
{
    public struct MemberId
    {
        public static readonly MemberId AuthorizedUser = new MemberId("me");

        private string id;

        public MemberId(string id)
        {
            checkId(id);
            this.id = id;
        }

        public static implicit operator MemberId(string id)
        {
            return new MemberId(id);
        }

        public static implicit operator string(MemberId id)
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
