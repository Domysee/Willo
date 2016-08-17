using Tapi.Authorization;
using Tapi.TrelloEntities.Board;
using Tapi.WebConnection;

namespace Tapi
{
    public interface ITrello
    {
        IBoards Boards { get; }

        void Authorize(ApplicationKey applicationKey, AuthorizationToken authorizationToken);
    }
}