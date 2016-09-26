using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Willo.Logic;
using Willo.View.Setup;
using Willo.Logic.Components.Login;
using Tapi.Authorization;
using Willo.Logic.Infrastructure;

namespace Willo.View.Components.Login
{
    public class Register : IRegisterComponent
    {
        void IRegisterComponent.Register(IUnityContainer dependencyInjectionContainer, IMessageBroker messageBroker)
        {
            dependencyInjectionContainer.RegisterType<IAuthorizationUrlCreator, AuthorizationUrlCreator>();

            messageBroker.RegisterHandler(dependencyInjectionContainer.Resolve<AuthorizationUrlQueryHandler>());
            messageBroker.RegisterHandler(dependencyInjectionContainer.Resolve<IsAuthorizationTokenQueryHandler>());

            messageBroker.RegisterHandler(dependencyInjectionContainer.Resolve<AuthorizeCommandHandler>());
        }
    }
}
