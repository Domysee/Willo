using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi;
using Willo.Logic;
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
                    instance = new DependencyInjection();
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
            Container.RegisterType<Trello>();
            Container.RegisterType<LoginViewmodel>();
            Container.RegisterType<LoginLogic>();
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
