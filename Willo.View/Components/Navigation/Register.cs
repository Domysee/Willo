using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Willo.Logic;
using Willo.View.Setup;
using Willo.View.Components.Navigation.Messaging;
using Willo.Logic.Infrastructure;

namespace Willo.View.Components.Navigation
{
    public class Register : IRegisterComponent
    {
        void IRegisterComponent.Register(IUnityContainer dependencyInjectionContainer, IMessageBroker messageBroker)
        {
            dependencyInjectionContainer.RegisterInstance(new NavigationCreator());
            dependencyInjectionContainer.RegisterInstance(new NavigationManager());

            messageBroker.RegisterHandler(dependencyInjectionContainer.Resolve<AddNavigationRegionCommandHandler>());
            messageBroker.RegisterHandler(dependencyInjectionContainer.Resolve<NavigateRegionCommandHandler>());
        }
    }
}
