using System.Threading.Tasks;
using Tapi.Authorization;

namespace Tapi.WebConnection
{
    public interface IWebRequestHandler
    {
        Task<string> Get(string url, ApplicationKey applicationKey, AuthorizationToken authorizationToken);
    }
}