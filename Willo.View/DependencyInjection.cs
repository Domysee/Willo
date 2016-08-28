using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Willo.View
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

            Container.RegisterType<IAuthorizationUrlCreator, AuthorizationUrlCreator>();

            var queryHandlerStore = new QueryHandlerStore();
            var commandHandlerStore = new CommandHandlerStore();
            var messageBroker = new MessageBroker(queryHandlerStore, commandHandlerStore);
            Container.RegisterInstance<IMessageBroker>(messageBroker);

            Container.RegisterInstance(new NavigationCreator());
            Container.RegisterInstance(new NavigationManager());

            messageBroker.RegisterHandler(instance.Resolve<AuthorizationUrlQueryHandler>());
            messageBroker.RegisterHandler(instance.Resolve<IsAuthorizationTokenQueryHandler>());
            messageBroker.RegisterHandler(instance.Resolve<BoardOverviewQueryHandler>());

            messageBroker.RegisterHandler(instance.Resolve<AuthorizeCommandHandler>());
            messageBroker.RegisterHandler(instance.Resolve<AddNavigationRegionCommandHandler>());
            messageBroker.RegisterHandler(instance.Resolve<NavigateRegionCommandHandler>());
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
