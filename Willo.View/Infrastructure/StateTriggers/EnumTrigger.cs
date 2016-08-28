using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Willo.View.Infrastructure.StateTriggers
{
    public class EnumTrigger : StateTriggerBase
    {
        public object Target
        {
            get { return (object)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(object), typeof(EnumTrigger), new PropertyMetadata(null, Changed));

        public object Value
        {
            get { return (object)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(EnumTrigger), new PropertyMetadata(null, Changed));

        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var trigger = d as EnumTrigger;
            if (trigger.Target == null || trigger.Value == null)
                trigger.SetActive(false);
            else
                trigger.SetActive((int)trigger.Target == (int)trigger.Value);
        }
    }
}
