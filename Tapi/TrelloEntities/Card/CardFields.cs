using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Card
{
    public class CardFields
    {
        public bool Id { get; set; }
        public bool ShortId { get; set; }
        public bool Name { get; set; }
        public bool Description { get; set; }
        public bool DescriptionData { get; set; }
        public bool IsClosed { get; set; }
        public bool IsUserSubscribed { get; set; }
        public bool DueDate { get; set; }
        public bool Email { get; set; }
        public bool Badges { get; set; }
        public bool CheckItemStates { get; set; }
        public bool ContainingBoardId { get; set; }
        public bool ContainingListId { get; set; }
        public bool ContainedChecklistIds { get; set; }
        public bool MemberIds { get; set; }
        public bool VotedMemberIds { get; set; }
        public bool AttachmentCoverId { get; set; }
        public bool ManualCoverAttachment { get; set; }
        public bool Labels { get; set; }
        public bool LabelIds { get; set; }
        public bool LastActivity { get; set; }
        public bool Position { get; set; }
        public bool Url { get; set; }
        public bool ShortUrl { get; set; }
        public bool ShortLink { get; set; }

        public static readonly CardFields All = new CardFields
        {
            Id = true,
            ShortId = true,
            Name = true,
            Description = true,
            DescriptionData = true,
            IsClosed = true,
            IsUserSubscribed = true,
            DueDate = true,
            Email = true,
            Badges = true,
            CheckItemStates = true,
            ContainingBoardId = true,
            ContainingListId = true,
            ContainedChecklistIds = true,
            MemberIds = true,
            VotedMemberIds = true,
            AttachmentCoverId = true,
            ManualCoverAttachment = true,
            Labels = true,
            LabelIds = true,
            LastActivity = true,
            Position = true,
            Url = true,
            ShortUrl = true,
            ShortLink = true
        };
    }
}
