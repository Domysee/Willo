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
    }
}
