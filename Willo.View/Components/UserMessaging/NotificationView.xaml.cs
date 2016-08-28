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

namespace Willo.View.Components.UserMessaging
{
    public sealed partial class NotificationView : UserControl
    {
        public NotificationViewViewmodel Viewmodel { get; }

        public NotificationView()
        {
            this.InitializeComponent();
            this.Viewmodel = DependencyInjection.Instance.Resolve<NotificationViewViewmodel>();
            this.DataContext = this.Viewmodel;
            this.Viewmodel.Initialize();
        }

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Message.Width = e.NewSize.Width;
        }
    }
}
