using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Board
{
    /// <summary>
    /// defines a class to specify which properties should be loaded by the api
    /// </summary>
    public class BoardOverviewQueryParameters
    {
        public bool Name { get; set; }
        public bool Description { get; set; }
        public bool DescriptionData { get; set; }
        public bool IsClosed { get; set; }
        public bool IsUserInvited { get; set; }
        public bool IsUserSubscribed { get; set; }
        public bool IsStarredByUser { get; set; }
        public bool LastActivity { get; set; }
        public bool LastView { get; set; }
        public bool Url { get; set; }
        public bool ShortUrl { get; set; }
        public bool ShortLink { get; set; }
        public bool Pinned { get; set; }
        public bool OrganizationId { get; set; }
        public bool Invitations { get; set; }
        public bool PowerUps { get; set; }
        public bool Preferences { get; set; }
        public bool Memberships { get; set; }
        public bool LabelNames { get; set; }

        /// <summary>
        /// Creates BoardProperties with all properties set to false
        /// Id is queried by default
        /// </summary>
        public BoardOverviewQueryParameters() { }

        public override string ToString()
        {
            var apiPropertyNames = new List<string>();
            foreach (var property in this.GetType().GetProperties())
            {
                var apiPropertyName = PropertyMappings.BoardMappings[property.Name];
                var includeProperty = (bool)property.GetValue(this);
                if (includeProperty) apiPropertyNames.Add(apiPropertyName);
            }
            return String.Join(",", apiPropertyNames);
        }

        public static readonly BoardOverviewQueryParameters All = new BoardOverviewQueryParameters
        {
            Name = true,
            Description = true,
            DescriptionData = true,
            IsClosed = true,
            IsUserInvited = true,
            IsUserSubscribed = true,
            IsStarredByUser = true,
            LastActivity = true,
            LastView = true,
            Url = true,
            ShortUrl = true,
            ShortLink = true,
            Pinned = true,
            OrganizationId = true,
            Invitations = true,
            PowerUps = true,
            Preferences = true,
            Memberships = true,
            LabelNames = true
        };
    }
}
