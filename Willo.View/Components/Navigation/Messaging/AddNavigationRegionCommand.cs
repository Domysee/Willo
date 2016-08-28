using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willo.Logic;
using Windows.UI.Xaml.Controls;

namespace Willo.View.Components.Navigation.Messaging
{
    public class AddNavigationRegionCommand : ICommand
    {
        public object Target { get; }
        public string NavigationRegionName { get; }

        public AddNavigationRegionCommand(object target, string navigationRegionName)
        {
            Target = target;
            NavigationRegionName = navigationRegionName;
        }
    }
}
