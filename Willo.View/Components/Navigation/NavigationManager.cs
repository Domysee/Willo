using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Willo.View.Components.Navigation
{
    public class NavigationManager
    {
        private IDictionary<string, IGuiNavigator> navigationRegions = new Dictionary<string, IGuiNavigator>();

        public void AddRegion(string name, IGuiNavigator navigator)
        {
            navigationRegions[name] = navigator;
        }

        public void RemoveRegion(string name)
        {
            navigationRegions.Remove(name);
        }

        public bool NavigateRegion(string name, UserControl content)
        {
            if (navigationRegions.ContainsKey(name))
            {
                var navigator = navigationRegions[name];
                navigator.NavigateTo(content);
                return true;
            }
            return false;
        }
    }
}
