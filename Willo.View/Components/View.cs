using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willo.View.Components.Navigation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Willo.View.Components
{
    public class View : UserControl
    {
        public object NavigationContainer
        {
            get { return (object)GetValue(NavigationContainerProperty); }
            set { SetValue(NavigationContainerProperty, value); }
        }

        public static readonly DependencyProperty NavigationContainerProperty =
            DependencyProperty.Register("NavigationContainer", typeof(object), typeof(View), new PropertyMetadata(null, (dependencyObject, args) => { (dependencyObject as View).initializeNavigator(); }));

        protected IGuiNavigator navigator;

        private void initializeNavigator()
        {
            navigator = new NavigationCreator().Create(NavigationContainer);
        }
    }
}
