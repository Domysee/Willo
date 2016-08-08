using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Willo.View.Components.Navigation
{
    public class ContentPresenterNavigator : IGuiNavigator
    {
        public ContentPresenter ContentPresenter { get; set; }

        public ContentPresenterNavigator()
        {

        }

        public ContentPresenterNavigator(ContentPresenter contentPresenter)
        {
            this.ContentPresenter = contentPresenter;
        }

        public void NavigateTo(UserControl view)
        {
            ContentPresenter.Content = view;
        }
    }
}
