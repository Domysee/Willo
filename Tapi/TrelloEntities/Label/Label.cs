using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Label
{
    public class Label
    {
        public LabelId Id { get; private set; }
        public string Name { get; private set; }
        public string ContainingBoardId { get; private set; }
        public string Color { get; private set; }
        public int UseCount { get; private set; }

        public static Label FromJson(JObject jobject)
        {
            var label = new Label();
            foreach (var property in label.GetType().GetProperties())
            {
                var apiPropertyName = PropertyMappings.LabelFieldMappings[property.Name];
                var jToken = jobject[apiPropertyName];
                if (jToken != null)
                    property.SetValue(label, jToken.ToObject(property.PropertyType));
            }
            return label;
        }
    }
}
