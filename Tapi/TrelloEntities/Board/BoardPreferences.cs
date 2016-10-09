using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Board
{
    public class BoardPreferences
    {
        public PermissionLevel PermissionLevel { get; private set; }
        public VotingPermission VotingPermission { get; private set; }
        public CommentPermission CommentPermission { get; private set; }
        public InvitationPermission InvitationPermission { get; private set; }
        public bool SelfJoin { get; private set; }
        public bool HasCardCovers { get; private set; }
        public CardAging CardAging { get; private set; }
        public bool IsCalendarFeedEnabled { get; private set; }
        public string BackgroundColorName { get; private set; }
        public string BackgroundColor { get; private set; }
        public object BackgroundImage { get; private set; }
        public object ScaledBackgroundImage { get; private set; }
        public bool HasBackgroundTitle { get; private set; }
        public BackgroundBrightness BackgroundBrightness { get; private set; }
        public bool PermissionLevelCanBePublic { get; private set; }
        public bool PermissionLevelCanBeTeam { get; private set; }
        public bool PermissionLevelCanBePrivate { get; private set; }
        public bool UserCanInvite { get; private set; }
    }
}
