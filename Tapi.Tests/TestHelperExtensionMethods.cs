using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Tapi.Tests
{
    public static class TestHelperExtensionMethods
    {
        public static void SetMember(this object target, string property, object value)
        {
            var propertyInfo = target.GetType().GetTypeInfo().GetProperty(property, BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.SetField | BindingFlags.SetProperty);
            propertyInfo.SetValue(target, value);
        }
    }
}
