using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities
{
    /// <summary>
    /// contains mappings from properties of C# classes to the Trello api
    /// </summary>
    public class PropertyMappings
    {
        public static readonly Dictionary<string, string> BoardFieldMappings = new Dictionary<string, string>
        {
            { nameof(Board.Board.Id), "id" },
            { nameof(Board.Board.Name), "name" },
            { nameof(Board.Board.Description), "desc" },
            { nameof(Board.Board.DescriptionData), "descData" },
            { nameof(Board.Board.IsClosed), "closed" },
            { nameof(Board.Board.IsUserInvited), "invited" },
            { nameof(Board.Board.IsUserSubscribed), "subscribed" },
            { nameof(Board.Board.IsStarredByUser), "starred" },
            { nameof(Board.Board.LastActivity), "dateLastActivity" },
            { nameof(Board.Board.LastView), "dateLastView" },
            { nameof(Board.Board.Url), "url" },
            { nameof(Board.Board.ShortUrl), "shortUrl" },
            { nameof(Board.Board.ShortLink), "shortLink" },
            { nameof(Board.Board.Pinned), "pinned" },
            { nameof(Board.Board.OrganizationId), "idOrganization" },
            { nameof(Board.Board.Invitations), "invitations" },
            { nameof(Board.Board.PowerUps), "powerUps" },
            { nameof(Board.Board.IdTags), "idTags" },
            { nameof(Board.Board.Preferences), "prefs" },
            { nameof(Board.Board.Memberships), "memberships" },
            { nameof(Board.Board.LabelNames), "labelNames" }
        };

        public static readonly Dictionary<string, string> CardFieldMappings = new Dictionary<string, string>
        {
            { nameof(Card.Card.Id), "id" },
            { nameof(Card.Card.ShortId), "idShort" },
            { nameof(Card.Card.Name), "name" },
            { nameof(Card.Card.Description), "desc" },
            { nameof(Card.Card.DescriptionData), "descData" },
            { nameof(Card.Card.IsClosed), "closed" },
            { nameof(Card.Card.IsUserSubscribed), "subscribed" },
            { nameof(Card.Card.DueDate), "due" },
            { nameof(Card.Card.Email), "email" },
            { nameof(Card.Card.Badges), "badges" },
            { nameof(Card.Card.CheckItemStates), "checkItemStates" },
            { nameof(Card.Card.ContainingBoardId), "idBoard" },
            { nameof(Card.Card.ContainingListId), "idList" },
            { nameof(Card.Card.ContainedChecklistIds), "idChecklists" },
            { nameof(Card.Card.MemberIds), "idMembers" },
            { nameof(Card.Card.VotedMemberIds), "idMembersVoted" },
            { nameof(Card.Card.AttachmentCoverId), "idAttachmentCover" },
            { nameof(Card.Card.ManualCoverAttachment), "manualCoverAttachment" },
            { nameof(Card.Card.Labels), "labels" },
            { nameof(Card.Card.LabelIds), "idLabels" },
            { nameof(Card.Card.LastActivity), "dateLastActivity" },
            { nameof(Card.Card.Position), "pos" },
            { nameof(Card.Card.Url), "url" },
            { nameof(Card.Card.ShortUrl), "shortUrl" },
            { nameof(Card.Card.ShortLink), "shortLink" }
        };
    }
}
