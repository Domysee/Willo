using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willo.View.Components.Navigation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Willo.View.Infrastructure
{
    public class Navigation : DependencyObject
    {
        public object NavigationContainer
        {
            get { return (object)GetValue(NavigationContainerProperty); }
            set { SetValue(NavigationContainerProperty, value); }
        }

        public static readonly DependencyProperty NavigationContainerProperty =
            DependencyProperty.Register("NavigationContainer", typeof(object), typeof(Navigation), new PropertyMetadata(null, (dependencyObject, args) => { (dependencyObject as Navigation).initializeNavigator(); }));

        public IGuiNavigator Navigator { get; set; }

        private void initializeNavigator()
        {
            Navigator = new NavigationCreator().Create(NavigationContainer);
        }
    }
}
