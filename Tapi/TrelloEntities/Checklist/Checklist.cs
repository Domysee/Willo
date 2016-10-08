using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Checklist
{
    public class Checklist
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string ContainingBoardId { get; private set; }
        public string ContainingCardId { get; private set; }
        public int Position { get; private set; }

        public static Checklist FromJson(JObject jobject)
        {
            var checklist = new Checklist();
            foreach (var property in checklist.GetType().GetProperties())
            {
                var apiPropertyName = PropertyMappings.ChecklistFieldMappings[property.Name];
                var jToken = jobject[apiPropertyName];
                if (jToken != null)
                    property.SetValue(checklist, jToken.ToObject(property.PropertyType));
            }
            return checklist;
        }
    }
}
