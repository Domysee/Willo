using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Organization
{
    public class OrganizationFields
    {
        public bool Id { get; private set; }
        public bool Name { get; private set; }
        public bool DisplayName { get; private set; }
        public bool Url { get; private set; }
        public bool Website { get; private set; }
        public bool LogoHash { get; private set; }
        public bool Description { get; private set; }
        public bool DescriptionData { get; private set; }
        public bool BillableMemberCount { get; private set; }
        public bool Preferences { get; private set; }
        public bool BoardIds { get; private set; }
        public bool Invitations { get; private set; }
        public bool Memberships { get; private set; }
        public bool PowerUps { get; private set; }
        public bool PremiumFeatures { get; private set; }
        public bool Products { get; private set; }
        public bool IsCurrentUserInvited { get; private set; }

        public static readonly OrganizationFields All = new OrganizationFields
        {
            Id = true,
            Name = true,
            DisplayName = true,
            Url = true,
            Website = true,
            LogoHash = true,
            Description = true,
            DescriptionData = true,
            BillableMemberCount = true,
            Preferences = true,
            BoardIds = true,
            Invitations = true,
            Memberships = true,
            PowerUps = true,
            PremiumFeatures = true,
            Products = true,
            IsCurrentUserInvited = true
        };
    }
}
