using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Card
{
    public class AttachmentId
    {
        private string id;

        public AttachmentId(string id)
        {
            checkId(id);
            this.id = id;
        }

        public static implicit operator AttachmentId(string id)
        {
            return new AttachmentId(id);
        }

        public static implicit operator string(AttachmentId id)
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
