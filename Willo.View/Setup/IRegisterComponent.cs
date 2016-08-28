using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willo.Logic;

namespace Willo.View.Setup
{
    /// <summary>
    /// Interface used for registering the classes and handlers of components
    /// Every component must have one class that implements it
    /// Its responsibility also includes registering the handlers of Willo.Logic
    /// </summary>
    public interface IRegisterComponent
    {
        void Register(IUnityContainer dependencyInjectionContainer, IMessageBroker messageBroker);
    }
}
