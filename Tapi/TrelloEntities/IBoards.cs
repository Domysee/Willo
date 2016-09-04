using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Board
{
    public interface IBoards
    {
        Task<IEnumerable<Board>> GetAll(MemberId memberId, BoardProperties properties = null);
    }
}