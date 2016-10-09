using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Board
{
    public enum CommentPermission
    {
        Disabled,   //No one is allowed to comment
        Members,    //Allow admins and normal members to comment
        MembersAndObservers,    //Allow admins, normal members, and observers to comment
        Team,   //Allow admins, normal members, observers, and team members to comment
        Public  //Allow any Trello member to comment
    }
}
