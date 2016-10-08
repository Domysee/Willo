using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Notification
{
    public class Notification
    {
        public string Id { get; private set; }
        public DateTime Date { get; private set; }
        public string CreatorId { get; private set; }
        public string Type { get; private set; }
        public bool IsUnread { get; private set; }
        public object Data { get; private set; }

        public static Notification FromJson(JObject jobject)
        {
            var organization = new Notification();
            foreach (var property in organization.GetType().GetProperties())
            {
                var apiPropertyName = PropertyMappings.NotificationFieldMappings[property.Name];
                var jToken = jobject[apiPropertyName];
                if (jToken != null)
                    property.SetValue(organization, jToken.ToObject(property.PropertyType));
            }
            return organization;
        }
    }
}
