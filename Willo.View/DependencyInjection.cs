﻿using Microsoft.Practices.Unity;
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
            Container.RegisterInstance(new Trello());

            var queryHandlerStore = new QueryHandlerStore();
            var commandHandlerStore = new CommandHandlerStore();
            var messageBroker = new MessageBroker(queryHandlerStore, commandHandlerStore);
            Container.RegisterInstance(messageBroker);

            messageBroker.RegisterHandler(new AuthorizationUrlQueryHandler());
            messageBroker.RegisterHandler(new IsAuthorizationTokenQueryHandler());

            messageBroker.RegisterHandler(instance.Resolve<AuthorizeCommandHandler>());
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
