using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Willo.View.Components.BoardView
{
    public sealed partial class BoardView : UserControl
    {
        public BoardViewViewmodel Viewmodel { get; }

        public BoardView()
        {
            this.InitializeComponent();
            this.Viewmodel = DependencyInjection.Instance.Resolve<BoardViewViewmodel>();
            this.DataContext = this.Viewmodel;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await this.Viewmodel.Initialize();
        }
    }
}
