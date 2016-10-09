using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Card
{
    public class AttachmentPreview
    {
        public AttachmentPreviewId Id { get; private set; }
        public long ByteCount { get; private set; }
        public string Url { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public bool IsScaled { get; private set; }
    }
}
