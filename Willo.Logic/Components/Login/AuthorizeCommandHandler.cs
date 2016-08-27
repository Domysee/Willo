using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi;
using Tapi.WebConnection;
using Willo.Logic.Errors;

namespace Willo.Logic.Components.Login
{
    public class AuthorizeCommandHandler : CommandHandlerBase<AuthorizeCommand>
    {
        private ITrello api;

        public AuthorizeCommandHandler(ITrello api)
        {
            this.api = api;
        }

        public override async Task<IEnumerable<IError>> Handle(AuthorizeCommand command)
        {
            var errors = new List<IError>();
            try
            {
                await api.Authorize(TrelloData.AppplicationKey, command.AuthorizationToken);
            }
            catch (AuthorizationDeniedException)
            {
                errors.Add(new AuthorizationDeniedError());
            }
            catch (RequestFailedException)
            {
                errors.Add(new RequestFailedError());
            }
            catch (NetworkException)
            {
                errors.Add(new NetworkError());
            }
            return errors;
        }
    }
}
