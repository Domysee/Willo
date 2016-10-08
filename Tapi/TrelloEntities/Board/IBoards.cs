using System.Collections.Generic;
using System.Threading.Tasks;
using Tapi.TrelloEntities.Member;

namespace Tapi.TrelloEntities.Board
{
    public interface IBoards
    {
        /// <summary>
        /// gets all boards of the given user
        /// </summary>
        /// <param name="memberId">the user to get the boards from</param>
        /// <param name="queryParameters">defines which properties are queried</param>
        /// <returns></returns>
        /// <exception cref="AuthorizationDeniedException">Occurs if the user revoked the authorization token</exception>
        /// <exception cref="RequestFailedException">When the response status code does not indicate success</exception>
        Task<IEnumerable<Board>> GetAll(MemberId memberId, BoardOverviewQueryParameters queryParameters = null);

        /// <summary>
        /// gets the board with the given id
        /// </summary>
        /// <param name="boardId"></param>
        /// <param name="queryParameters">defines which properties are queried</param>
        /// <returns></returns>
        /// <exception cref="AuthorizationDeniedException">Occurs if the user revoked the authorization token</exception>
        /// <exception cref="RequestFailedException">When the response status code does not indicate success</exception>
        Task<Board> Get(string boardId, BoardQueryParameters queryParameters);
    }
}