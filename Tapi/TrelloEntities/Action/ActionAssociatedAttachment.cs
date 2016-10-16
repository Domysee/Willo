using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.TrelloEntities.Member;

namespace Tapi.TrelloEntities.Card
{
    public class ActionAssociatedAttachment
    {
        public AttachmentId Id { get; private set; }
        public string Name { get; private set; }
        public string Url { get; private set; }
        public string PreviewUrl { get; private set; }
        public string PreviewUrl2x { get; private set; }
    }
}
