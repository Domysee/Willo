using System.Threading.Tasks;
using Tapi.Authorization;

namespace Tapi.WebConnection
{
    /// <summary>
    /// Used to make requests to the Trello api, and handles authentication of the requests
    /// </summary>
    public interface IWebRequestHandler
    {
        /// <summary>
        /// Handles requests to the given url and authenticates using the given parameters
        /// </summary>
        /// <param name="url"></param>
        /// <param name="applicationKey"></param>
        /// <param name="authorizationToken"></param>
        /// <returns>the response string</returns>
        /// <exception cref="RequestFailedException">When the response status code does not indicate success</exception>
        /// <exception cref="NetworkException">When an exception is thrown during the network request</exception>
        Task<string> Get(string url, ApplicationKey applicationKey, AuthorizationToken authorizationToken);
    }
}