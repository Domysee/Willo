using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Member
{
    public class Member
    {
        public string Id { get; private set; }
        public string Username { get; private set; }
        public string FullName { get; private set; }
        public string Initials { get; private set; }
        public string Email { get; private set; }
        public object AvatarHash { get; private set; }
        public string AvatarSource { get; private set; }
        public string GravatarHash { get; private set; }
        public object UploadedAvatarHash { get; private set; }
        public string Bio { get; private set; }
        public object BioData { get; private set; }
        public bool IsConfirmed { get; private set; }
        public string MemberType { get; private set; }
        public IEnumerable<string> BoardIds { get; private set; }
        public IEnumerable<string> PinnedBoardIds { get; private set; }
        public IEnumerable<string> OrganizationIds { get; private set; }
        public string EnterpriseId { get; private set; }
        public string PremOrgsAdminId { get; private set; }
        public IEnumerable<string> LoginTypes { get; private set; }
        public IEnumerable<string> DismissedOneTimeMessages { get; private set; }
        public object Preferences { get; private set; }
        public IEnumerable<object> PremiumFeatures { get; private set; }
        public IEnumerable<object> Products { get; private set; }
        public string Status { get; private set; }
        public IEnumerable<object> Trophies { get; private set; }
        public string Url { get; private set; }

        public static Member FromJson(JObject jobject)
        {
            var member = new Member();
            foreach (var property in member.GetType().GetProperties())
            {
                var apiPropertyName = PropertyMappings.MemberFieldMappings[property.Name];
                var jToken = jobject[apiPropertyName];
                if (jToken != null)
                    property.SetValue(member, jToken.ToObject(property.PropertyType));
            }
            return member;
        }
    }
}
