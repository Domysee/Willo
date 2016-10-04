using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Board
{
    /// <summary>
    /// contains mappings from properties of C# classes to the Trello api
    /// </summary>
    public class PropertyMappings
    {
        public static readonly Dictionary<string, string> BoardFieldMappings = new Dictionary<string, string>
        {
            {"Id", "id"},
            {"Name", "name"},
            {"Description", "desc"},
            {"DescriptionData", "descData"},
            {"IsClosed", "closed"},
            {"IsUserInvited", "invited"},
            {"IsUserSubscribed", "subscribed"},
            {"IsStarredByUser", "starred"},
            {"LastActivity", "dateLastActivity" },
            {"LastView", "dateLastView"},
            {"Url","url" },
            {"ShortUrl", "shortUrl" },
            {"ShortLink", "shortLink"},
            {"Pinned", "pinned"},
            {"OrganizationId", "idOrganization"},
            {"Invitations", "invitations" },
            {"PowerUps", "powerUps"},
            {"IdTags", "idTags" },
            {"Preferences","prefs" },
            {"Memberships","memberships" },
            {"LabelNames" ,"labelNames"}
        };
    }
}
