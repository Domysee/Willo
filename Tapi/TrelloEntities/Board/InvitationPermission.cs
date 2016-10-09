using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Board
{
    public enum InvitationPermission
    {
        Admins, //Allow only admins to add and remove members
        Members //Allow all members and admins to add and remove members
    }
}
