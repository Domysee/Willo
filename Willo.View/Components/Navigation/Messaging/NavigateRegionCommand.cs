using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willo.Logic;
using Windows.UI.Xaml.Controls;
using Willo.Logic.Infrastructure;

namespace Willo.View.Components.Navigation.Messaging
{
    public class NavigateRegionCommand : ICommand
    {
        public string NavigationRegionName { get; }
        public UserControl Content { get; }

        public NavigateRegionCommand(string navigationRegionName, UserControl content)
        {
            NavigationRegionName = navigationRegionName;
            Content = content;
        }
    }
}
