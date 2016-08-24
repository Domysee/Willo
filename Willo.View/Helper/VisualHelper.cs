using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Willo.View.Helper
{
    public class VisualHelper
    {
        public static IEnumerable<DependencyObject> GetChildren(DependencyObject element)
        {
            var children = new List<DependencyObject>();
            var elementsToTraverse = new Stack<DependencyObject>();
            elementsToTraverse.Push(element);

            while(elementsToTraverse.Count > 0)
            {
                var current = elementsToTraverse.Pop();
                var childrenCount = VisualTreeHelper.GetChildrenCount(current);
                for(var i = 0; i < childrenCount; i++)
                {
                    var child = VisualTreeHelper.GetChild(current, i);
                    children.Add(child);
                    elementsToTraverse.Push(child);
                }
            }
            return children;
        }
    }
}
