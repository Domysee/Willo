using System.Threading.Tasks;
using Tapi.Authorization;
using Tapi.TrelloEntities.Board;
using Tapi.WebConnection;

namespace Tapi
{
    public interface ITrello
    {
        IBoards Boards { get; }

        Task Authorize(ApplicationKey applicationKey, AuthorizationToken authorizationToken);
    }
}