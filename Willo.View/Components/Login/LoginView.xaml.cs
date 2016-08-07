using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Willo.View.Components.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Willo.View.Components.Login
{
    public sealed partial class LoginView : UserControl
    {
        public object NavigationTarget
        {
            get { return (object)GetValue(NavigationTargetProperty); }
            set { SetValue(NavigationTargetProperty, value); }
        }

        public static readonly DependencyProperty NavigationTargetProperty =
            DependencyProperty.Register("NavigationTarget", typeof(object), typeof(LoginView), new PropertyMetadata(null, (dependencyObject, args) => { (dependencyObject as LoginView).initializeNavigator(); }));

        private IGuiNavigator navigator;
        public LoginViewmodel Viewmodel { get; }

        public LoginView()
        {
            this.InitializeComponent();
            this.Viewmodel = DependencyInjection.Instance.Resolve<LoginViewmodel>();
            this.DataContext = this.Viewmodel;
            this.Viewmodel.Initialize();
            this.Viewmodel.NavigationRequested += Viewmodel_NavigationRequested;
        }

        private void initializeNavigator()
        {
            navigator = new NavigationCreator().Create(NavigationTarget);
        }

        private void Viewmodel_NavigationRequested(Type viewType)
        {
            var v = (UserControl)Activator.CreateInstance(viewType);
            navigator.NavigateTo(v);
        }
    }
}
