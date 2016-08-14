using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi;
using Willo.Logic;
using Willo.Logic.Login;
using Willo.View.Components.Login;

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
            var queryHandlerStore = new QueryHandlerStore();
            var messageBroker = new MessageBroker(queryHandlerStore);
            messageBroker.RegisterHandler(new AuthorizationUrlQueryHandler());
            Container.RegisterInstance(messageBroker);
            Container.RegisterInstance(new Trello());
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
