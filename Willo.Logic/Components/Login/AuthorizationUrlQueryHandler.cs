﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.Authorization;
using Willo.Logic.Infrastructure;

namespace Willo.Logic.Components.Login
{
    public class AuthorizationUrlQueryHandler : QueryHandlerBase<AuthorizationUrlQuery, string>
    {
        private IAuthorizationUrlCreator urlCreator;

        public AuthorizationUrlQueryHandler(IAuthorizationUrlCreator urlCreator)
        {
            this.urlCreator = urlCreator;
        }

        public override async Task<string> Handle(AuthorizationUrlQuery query)
        {
            return urlCreator.Create(TrelloData.AppplicationKey, TrelloData.ApplicationName, AuthorizationScope.ReadWriteAccount, AuthorizationExpiration.Never);
        }
    }
}
