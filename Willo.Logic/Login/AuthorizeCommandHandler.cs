using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi;

namespace Willo.Logic.Login
{
    public class AuthorizeCommandHandler : CommandHandlerBase<AuthorizeCommand>
    {
        private Trello api;

        public AuthorizeCommandHandler(Trello api)
        {
            this.api = api;
        }

        public override IEnumerable<IError> Handle(AuthorizeCommand command)
        {
            api.Authorize(TrelloData.AppplicationKey, command.AuthorizationToken);
            return null;
        }
    }
}
