using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Board
{
    public interface IBoards
    {
        /// <summary>
        /// gets all boards of the given user
        /// </summary>
        /// <param name="memberId">the user to get the boards from</param>
        /// <param name="properties">the properties that should be returned by the api</param>
        /// <returns></returns>
        /// <exception cref="AuthorizationDeniedException">Occurs if the user revoked the authorization token</exception>
        /// <exception cref="RequestFailedException">When the response status code does not indicate success</exception>
        Task<IEnumerable<Board>> GetAll(MemberId memberId, BoardProperties properties = null);
    }
}