using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Willo.View.Components.Navigation
{
    public class ContentControlNavigator : IGuiNavigator
    {
        public ContentControl ContentControl { get; set; }

        public ContentControlNavigator()
        {

        }

        public ContentControlNavigator(ContentControl contentControl)
        {
            this.ContentControl = contentControl;
        }

        public void NavigateTo(UserControl view)
        {
            ContentControl.Content = view;
        }
    }
}
