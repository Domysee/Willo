using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Organization
{
    public class Organization
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string DisplayName { get; private set; }
        public string Url { get; private set; }
        public string Website { get; private set; }
        public object LogoHash { get; private set; }
        public object Description { get; private set; }
        public object DescriptionData { get; private set; }
        public int BillableMemberCount { get; private set; }
        public object Preferences { get; private set; }
        public IEnumerable<string> BoardIds { get; private set; }
        public IEnumerable<object> Invitations { get; private set; }
        public IEnumerable<object> Memberships { get; private set; }
        public IEnumerable< object >PowerUps { get; private set; }
        public IEnumerable<object> PremiumFeatures { get; private set; }
        public IEnumerable<object> Products { get; private set; }
        public bool IsCurrentUserInvited { get; private set; }

        public static Organization FromJson(JObject jobject)
        {
            var organization = new Organization();
            foreach (var property in organization.GetType().GetProperties())
            {
                var apiPropertyName = PropertyMappings.OrganizationFieldMappings[property.Name];
                var jToken = jobject[apiPropertyName];
                if (jToken != null)
                    property.SetValue(organization, jToken.ToObject(property.PropertyType));
            }
            return organization;
        }
    }
}
