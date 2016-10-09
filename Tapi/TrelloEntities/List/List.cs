using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.List
{
    public class List
    {
        public ListId Id { get; private set; }
        public string Name { get; private set; }
        public bool IsClosed { get; private set; }
        public bool IsUserSubscribed { get; private set; }
        public string ContainingBoardId { get; private set; }
        public int Position { get; private set; }

        public static List FromJson(JObject jobject)
        {
            var list = new List();
            foreach (var property in list.GetType().GetProperties())
            {
                var apiPropertyName = PropertyMappings.ListFieldMappings[property.Name];
                var jToken = jobject[apiPropertyName];
                if (jToken != null)
                    property.SetValue(list, jToken.ToObject(property.PropertyType));
            }
            return list;
        }
    }
}
