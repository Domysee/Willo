using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Member
{
    public class MemberFields
    {
        public bool Id { get; private set; }
        public bool Username { get; private set; }
        public bool FullName { get; private set; }
        public bool Initials { get; private set; }
        public bool Email { get; private set; }
        public bool AvatarHash { get; private set; }
        public bool AvatarSource { get; private set; }
        public bool GravatarHash { get; private set; }
        public bool UploadedAvatarHash { get; private set; }
        public bool Bio { get; private set; }
        public bool BioData { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool MemberType { get; private set; }
        public bool BoardIds { get; private set; }
        public bool PinnedBoardIds { get; private set; }
        public bool OrganizationIds { get; private set; }
        public bool EnterpriseId { get; private set; }
        public bool PremOrgsAdminId { get; private set; }
        public bool LoginTypes { get; private set; }
        public bool DismissedOneTimeMessages { get; private set; }
        public bool Preferences { get; private set; }
        public bool PremiumFeatures { get; private set; }
        public bool Products { get; private set; }
        public bool Status { get; private set; }
        public bool Trophies { get; private set; }
        public bool Url { get; private set; }

        public static readonly MemberFields All = new MemberFields
        {
            Id = true,
            Username = true,
            FullName = true,
            Initials = true,
            Email = true,
            AvatarHash = true,
            AvatarSource = true,
            GravatarHash = true,
            UploadedAvatarHash = true,
            Bio = true,
            BioData = true,
            IsConfirmed = true,
            MemberType = true,
            BoardIds = true,
            PinnedBoardIds = true,
            OrganizationIds = true,
            EnterpriseId = true,
            PremOrgsAdminId = true,
            LoginTypes = true,
            DismissedOneTimeMessages = true,
            Preferences = true,
            PremiumFeatures = true,
            Products = true,
            Status = true,
            Trophies = true,
            Url = true
        };
    }
}
