using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Willo.View.Components.Navigation
{
    public interface IGuiNavigator
    {
        void NavigateTo(UserControl view);
    }
}
