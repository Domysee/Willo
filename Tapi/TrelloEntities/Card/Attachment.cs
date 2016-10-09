using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.TrelloEntities.Member;

namespace Tapi.TrelloEntities.Card
{
    public class Attachment
    {
        public AttachmentId Id { get; private set; }
        public long ByteCount { get; private set; }
        public DateTime AddDate { get; private set; }
        public string EdgeColor { get; private set; }
        public MemberId CreatorId { get; private set; }
        public bool IsUpload { get; private set; }
        public string MimeType { get; private set; }
        public string Name { get; private set; }
        public string Url { get; private set; }
    }
}
