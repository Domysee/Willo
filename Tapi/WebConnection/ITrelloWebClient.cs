using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Tapi.Authorization;

namespace Tapi.WebConnection
{
    public interface ITrelloWebClient
    {
        bool IsAuthorized { get; }

        void Authorize(ApplicationKey applicationKey, AuthorizationToken authorizationToken);
        Task<JToken> Get(string url);
        Task<T> Get<T>(string url) where T : JToken;
    }
}