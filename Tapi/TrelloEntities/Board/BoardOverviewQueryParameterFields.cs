using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Board
{
    public class BoardOverviewQueryParameterFields
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

        public static readonly BoardOverviewQueryParameterFields Default = All;
        public static readonly BoardOverviewQueryParameterFields All = new BoardOverviewQueryParameterFields
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
