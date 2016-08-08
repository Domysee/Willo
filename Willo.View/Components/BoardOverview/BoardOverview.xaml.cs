﻿using System;
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

namespace Willo.View.Components.BoardOverview
{
    public sealed partial class BoardOverview : View
    {
        public BoardOverviewViewModel Viewmodel { get; }

        public BoardOverview()
        {
            this.InitializeComponent();
            this.Viewmodel = DependencyInjection.Instance.Resolve<BoardOverviewViewModel>();
            this.DataContext = this.Viewmodel;
            this.Viewmodel.Initialize();
        }
    }
}
