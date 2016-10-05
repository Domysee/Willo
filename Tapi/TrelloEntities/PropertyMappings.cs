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
        public static readonly Dictionary<string, string> ActionFieldMappings = new Dictionary<string, string>
        {
            { nameof(Action.Action.Id), "id" },
            { nameof(Action.Action.CreatorId), "idMemberCreator" },
            { nameof(Action.Action.Type), "type" },
            { nameof(Action.Action.Data), "data" },
        };

        public static readonly Dictionary<string, string> BoardFieldMappings = new Dictionary<string, string>
        {
            { nameof(Board.Board.IsClosed), "closed" },
            { nameof(Board.Board.LastActivity), "dateLastActivity" },
            { nameof(Board.Board.LastView), "dateLastView" },
            { nameof(Board.Board.Description), "desc" },
            { nameof(Board.Board.DescriptionData), "descData" },
            { nameof(Board.Board.Id), "id" },
            { nameof(Board.Board.OrganizationId), "idOrganization" },
            { nameof(Board.Board.IdTags), "idTags" },
            { nameof(Board.Board.Invitations), "invitations" },
            { nameof(Board.Board.IsUserInvited), "invited" },
            { nameof(Board.Board.LabelNames), "labelNames" },
            { nameof(Board.Board.Memberships), "memberships" },
            { nameof(Board.Board.Name), "name" },
            { nameof(Board.Board.Pinned), "pinned" },
            { nameof(Board.Board.PowerUps), "powerUps" },
            { nameof(Board.Board.Preferences), "prefs" },
            { nameof(Board.Board.ShortLink), "shortLink" },
            { nameof(Board.Board.ShortUrl), "shortUrl" },
            { nameof(Board.Board.IsStarredByUser), "starred" },
            { nameof(Board.Board.IsUserSubscribed), "subscribed" },
            { nameof(Board.Board.Url), "url" }
        };

        public static readonly Dictionary<string, string> CardFieldMappings = new Dictionary<string, string>
        {
            { nameof(Card.Card.Badges), "badges" },
            { nameof(Card.Card.CheckItemStates), "checkItemStates" },
            { nameof(Card.Card.IsClosed), "closed" },
            { nameof(Card.Card.LastActivity), "dateLastActivity" },
            { nameof(Card.Card.Description), "desc" },
            { nameof(Card.Card.DescriptionData), "descData" },
            { nameof(Card.Card.DueDate), "due" },
            { nameof(Card.Card.Email), "email" },
            { nameof(Card.Card.Id), "id" },
            { nameof(Card.Card.AttachmentCoverId), "idAttachmentCover" },
            { nameof(Card.Card.ContainingBoardId), "idBoard" },
            { nameof(Card.Card.ContainedChecklistIds), "idChecklists" },
            { nameof(Card.Card.LabelIds), "idLabels" },
            { nameof(Card.Card.ContainingListId), "idList" },
            { nameof(Card.Card.MemberIds), "idMembers" },
            { nameof(Card.Card.VotedMemberIds), "idMembersVoted" },
            { nameof(Card.Card.ShortId), "idShort" },
            { nameof(Card.Card.Labels), "labels" },
            { nameof(Card.Card.ManualCoverAttachment), "manualCoverAttachment" },
            { nameof(Card.Card.Name), "name" },
            { nameof(Card.Card.Position), "pos" },
            { nameof(Card.Card.IsUserSubscribed), "subscribed" },
            { nameof(Card.Card.ShortLink), "shortLink" },
            { nameof(Card.Card.ShortUrl), "shortUrl" },
            { nameof(Card.Card.Url), "url" }
        };

        public static readonly Dictionary<string, string> ChecklistFieldMappings = new Dictionary<string, string>
        {
            { nameof(Checklist.Checklist.Id), "id" },
            { nameof(Checklist.Checklist.ContainingBoardId), "idBoard" },
            { nameof(Checklist.Checklist.ContainingCardId), "idCard" },
            { nameof(Checklist.Checklist.Name), "name" },
            { nameof(Checklist.Checklist.Position), "pos" }
        };

        public static readonly Dictionary<string, string> LabelFieldMappings = new Dictionary<string, string>
        {
            { nameof(Label.Label.Id), "id" },
            { nameof(Label.Label.ContainingBoardId), "idBoard" },
            { nameof(Label.Label.Name), "name" },
            { nameof(Label.Label.Color), "color" },
            { nameof(Label.Label.UseCount), "uses" }
        };

        public static readonly Dictionary<string, string> ListFieldMappings = new Dictionary<string, string>
        {
            { nameof(List.List.IsClosed), "closed" },
            { nameof(List.List.Id), "id" },
            { nameof(List.List.ContainingBoardId), "idBoard" },
            { nameof(List.List.Name), "name" },
            { nameof(List.List.Position), "pos" },
            { nameof(List.List.IsUserSubscribed), "subscribed" }
        };

        public static readonly Dictionary<string, string> MemberFieldMappings = new Dictionary<string, string>
        {
            { nameof(Member.Member.Id), "id" },
            { nameof(Member.Member.AvatarHash), "avatarHash" },
            { nameof(Member.Member.AvatarSource), "avatarSource" },
            { nameof(Member.Member.Bio), "bio" },
            { nameof(Member.Member.BioData), "bioData" },
            { nameof(Member.Member.IsConfirmed), "confirmed" },
            { nameof(Member.Member.Email), "email" },
            { nameof(Member.Member.FullName), "fullName" },
            { nameof(Member.Member.GravatarHash), "gravatarHash" },
            { nameof(Member.Member.BoardIds), "idBoards" },
            { nameof(Member.Member.PinnedBoardIds), "idBoardsPinned" },
            { nameof(Member.Member.EnterpriseId), "idEnterprise" },
            { nameof(Member.Member.OrganizationIds), "idOrganizations" },
            { nameof(Member.Member.PremOrgsAdminId), "idPremOrgsAdmin" },
            { nameof(Member.Member.Initials), "initials" },
            { nameof(Member.Member.LoginTypes), "loginTypes" },
            { nameof(Member.Member.MemberType), "memberType" },
            { nameof(Member.Member.DismissedOneTimeMessages), "oneTimeMessagesDismissed" },
            { nameof(Member.Member.Preferences), "prefs" },
            { nameof(Member.Member.PremiumFeatures), "premiumFeatures" },
            { nameof(Member.Member.Products), "products" },
            { nameof(Member.Member.Status), "status" },
            { nameof(Member.Member.Trophies), "trophies" },
            { nameof(Member.Member.UploadedAvatarHash), "uploadedAvatarHash" },
            { nameof(Member.Member.Url), "url" },
            { nameof(Member.Member.Username), "username" }
        };

        public static readonly Dictionary<string, string> NotificationFieldMappings = new Dictionary<string, string>
        {
            { nameof(Notification.Notification.Id), "id" },
            { nameof(Notification.Notification.Date), "date" },
            { nameof(Notification.Notification.CreatorId), "idMemberCreator" },
            { nameof(Notification.Notification.Type), "type" },
            { nameof(Notification.Notification.IsUnread), "unread" },
            { nameof(Notification.Notification.Data), "data" },
        };

        public static readonly Dictionary<string, string> OrganizationFieldMappings = new Dictionary<string, string>
        {
            { nameof(Organization.Organization.Id), "id" },
            { nameof(Organization.Organization.BillableMemberCount), "billableMemberCount" },
            { nameof(Organization.Organization.Description), "desc" },
            { nameof(Organization.Organization.DescriptionData), "descData" },
            { nameof(Organization.Organization.DisplayName), "displayName" },
            { nameof(Organization.Organization.BoardIds), "idBoards" },
            { nameof(Organization.Organization.Invitations), "invitations" },
            { nameof(Organization.Organization.IsCurrentUserInvited), "invited" },
            { nameof(Organization.Organization.LogoHash), "logoHash" },
            { nameof(Organization.Organization.Memberships), "memberships" },
            { nameof(Organization.Organization.Name), "name" },
            { nameof(Organization.Organization.PowerUps), "powerUps" },
            { nameof(Organization.Organization.Preferences), "prefs" },
            { nameof(Organization.Organization.PremiumFeatures), "premiumFeatures" },
            { nameof(Organization.Organization.Products), "products" },
            { nameof(Organization.Organization.Url), "url" },
            { nameof(Organization.Organization.Website), "website" }
        };
    }
}
