using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Board
{
    public enum VotingPermission
    {
        Disabled,   //The voting power-up is inactive
        Members,    //All board members can vote
        MembersAndObservers,
        Team,
        Public
    }
}
