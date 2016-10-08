using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Tapi.TrelloEntities.Organization;

namespace Tapi.TrelloEntities.Board
{
    public class Board
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public object DescriptionData { get; private set; }
        public bool? IsClosed { get; private set; }
        public bool? IsUserInvited { get; private set; }
        public bool? IsUserSubscribed { get; private set; }
        public bool? IsStarredByUser { get; private set; }
        public bool? IsPinned { get; private set; }
        public DateTime? LastActivity { get; private set; }
        public DateTime? LastView { get; private set; }
        public Uri Url { get; private set; }
        public Uri ShortUrl { get; private set; }
        public string ShortLink { get; private set; }
        public OrganizationId OrganizationId { get; private set; }
        public object Invitations { get; private set; }
        public object PowerUps { get; private set; }
        public object IdTags { get; private set; }
        public object Preferences { get; private set; }
        public object Memberships { get; private set; }
        public object LabelNames { get; private set; }


        public static Board FromJson(JObject jobject)
        {
            var board = new Board();
            foreach (var property in board.GetType().GetProperties())
            {
                var apiPropertyName = PropertyMappings.BoardFieldMappings[property.Name];
                var jToken = jobject[apiPropertyName];
                if (jToken != null)
                    property.SetValue(board, jToken.ToObject(property.PropertyType));
            }
            return board;
        }
    }
}
