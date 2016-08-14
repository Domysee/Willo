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
using Willo.View.Infrastructure;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Willo.View.Components.Login
{
    public sealed partial class LoginView : UserControl
    {
        public Infrastructure.Navigation Navigation { get; set; }
        public LoginViewmodel Viewmodel { get; }

        public LoginView()
        {
            this.InitializeComponent();
            this.Navigation = new Infrastructure.Navigation();
            this.Viewmodel = DependencyInjection.Instance.Resolve<LoginViewmodel>();
            this.DataContext = this.Viewmodel;
            this.Viewmodel.Initialize().Wait();
            this.Viewmodel.NavigationToBoardOverviewRequested += Viewmodel_NavigationToBoardOverviewRequested;
        }

        private void Viewmodel_NavigationToBoardOverviewRequested(object sender, EventArgs e)
        {
            var boardOverview = new BoardOverview.BoardOverview();
            boardOverview.Navigation.NavigationContainer = this.Navigation.NavigationContainer;
            Navigation.Navigator.NavigateTo(boardOverview);
        }
    }
}
