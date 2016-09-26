using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Willo.Logic;
using Willo.View.Components.Navigation;
using Willo.View.Components.Navigation.Messaging;
using Willo.View.Setup;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Willo.Logic.Infrastructure;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Willo.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        IMessageBroker messageBroker;

        public MainPage()
        {
            this.InitializeComponent();
            messageBroker = DependencyInjection.Instance.Resolve<IMessageBroker>();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            messageBroker.Command(new AddNavigationRegionCommand(Content, NavigationRegions.Content));
        }
    }
}
