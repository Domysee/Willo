using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Willo.View.Components.Navigation
{
    public class NavigationCreator
    {
        public IGuiNavigator Create(object navigationTarget)
        {
            if (navigationTarget is ContentControl)
                return new ContentControlNavigator(navigationTarget as ContentControl);
            if (navigationTarget is ContentPresenter)
                return new ContentPresenterNavigator(navigationTarget as ContentPresenter);
            throw new ArgumentException("There is no suitable navigator for the given navigation target.");
        }
    }
}
