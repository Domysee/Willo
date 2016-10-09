using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Card
{
    public class AttachmentPreviewId
    {
        private string id;

        public AttachmentPreviewId(string id)
        {
            checkId(id);
            this.id = id;
        }

        public static implicit operator AttachmentPreviewId(string id)
        {
            return new AttachmentPreviewId(id);
        }

        public static implicit operator string(AttachmentPreviewId id)
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
