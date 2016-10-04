using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Card
{
    public class Card
    {
        public object Id { get; private set; }
        public object ShortId { get; private set; }
        public object Name { get; private set; }
        public object Description { get; private set; }
        public object DescriptionData { get; private set; }
        public object IsClosed { get; private set; }
        public object IsUserSubscribed { get; private set; }
        public object DueDate { get; private set; }
        public object Email { get; private set; }
        public object Badges { get; private set; }
        public object CheckItemStates { get; private set; }
        public object ContainingBoardId { get; private set; }
        public object ContainingListId { get; private set; }
        public object ContainedChecklistIds { get; private set; }
        public object MemberIds { get; private set; }
        public object VotedMemberIds { get; private set; }
        public object AttachmentCoverId { get; private set; }
        public object ManualCoverAttachment { get; private set; }
        public object Labels { get; private set; }
        public object LabelIds { get; private set; }
        public object LastActivity { get; private set; }
        public object Position { get; private set; }
        public object Url { get; private set; }
        public object ShortUrl { get; private set; }
        public object ShortLink { get; private set; }
    }
}
