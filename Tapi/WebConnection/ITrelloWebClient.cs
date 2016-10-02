using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Tapi.Authorization;

namespace Tapi.WebConnection
{
    public interface ITrelloWebClient
    {
        bool IsAuthorized { get; }


        /// <summary>
        /// authorizes the client
        /// </summary>
        /// <param name="applicationKey"></param>
        /// <param name="authorizationToken"></param>
        /// <returns></returns>
        /// <exception cref="AuthorizationDeniedException">Occurs if the authorization parameters are not accepted by the server</exception>
        /// <exception cref="RequestFailedException">When the response status code does not indicate success</exception>
        /// <exception cref="NetworkException">When an exception is thrown during the network request</exception>
        Task Authorize(ApplicationKey applicationKey, AuthorizationToken authorizationToken);

        /// <summary>
        /// Checks if the server accepts the authorization parameters
        /// </summary>
        /// <param name="applicationKey"></param>
        /// <param name="authorizationToken"></param>
        /// <returns></returns>
        /// <exception cref="RequestFailedException">When the response status code does not indicate success</exception>
        /// <exception cref="NetworkException">When an exception is thrown during the network request</exception>
        Task<bool> CheckAuthorizationParameters(ApplicationKey applicationKey, AuthorizationToken authorizationToken);

        /// <summary>
        /// returns the content of the given url, using the authorization
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <exception cref="AuthorizationDeniedException">Occurs if the user revoked the authorization token</exception>
        /// <exception cref="RequestFailedException">When the response status code does not indicate success</exception>
        /// <exception cref="NetworkException">When an exception is thrown during the network request</exception>
        Task<JToken> Get(string url);

        /// <summary>
        /// Handles the request and converts the response json to the given json class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <exception cref="AuthorizationDeniedException">Occurs if the user revoked the authorization token</exception>
        /// <exception cref="RequestFailedException">When the response status code does not indicate success</exception>
        /// <exception cref="NetworkException">When an exception is thrown during the network request</exception>
        Task<T> Get<T>(string url) where T : JToken;
    }
}