using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Willo.Logic;
using Willo.View.Setup;
using Willo.Logic.Infrastructure;

namespace Willo.View.Components.UserMessaging
{
    public class Register : IRegisterComponent
    {
        void IRegisterComponent.Register(IUnityContainer dependencyInjectionContainer, IMessageBroker messageBroker)
        {
        }
    }
}
