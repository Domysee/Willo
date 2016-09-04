using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tapi;
using Tapi.Authorization;
using Willo.Logic;
using Willo.Logic.Components.BoardOverview;
using Willo.Logic.Components.Login;
using Willo.View.Components.Login;
using Willo.View.Components.Navigation;
using Willo.View.Components.Navigation.Messaging;

namespace Willo.View.Setup
{
    public class DependencyInjection
    {
        private static DependencyInjection instance;
        public static DependencyInjection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DependencyInjection();
                    instance.Setup();
                }
                return instance;
            }
        }

        public IUnityContainer Container { get; }

        private DependencyInjection()
        {
            this.Container = new UnityContainer();
        }

        public void Setup()
        {
            Container.RegisterInstance<ITrello>(new Trello());

            var queryHandlerStore = new QueryHandlerStore();
            var commandHandlerStore = new CommandHandlerStore();
            var messageBroker = new MessageBroker(queryHandlerStore, commandHandlerStore);
            Container.RegisterInstance<IMessageBroker>(messageBroker);

            var componentRegisterTypes = this.GetType().GetTypeInfo().Assembly.GetTypes()
                .Where(t => t.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IRegisterComponent)));
            Container.RegisterTypes(componentRegisterTypes, WithMappings.FromAllInterfaces, t => t.FullName, //use the full name as registration name, so that the registration classes can have the same name
                WithLifetime.ContainerControlled);
            var componentRegisters = Container.ResolveAll<IRegisterComponent>();
            foreach (var componentRegister in componentRegisters)
                componentRegister.Register(Container, messageBroker);
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
