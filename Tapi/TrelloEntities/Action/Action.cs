using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tapi.TrelloEntities.Member;

namespace Tapi.TrelloEntities.Action
{
    public abstract class Action
    {
        public ActionId Id { get; private set; }
        public MemberId CreatorId { get; private set; }
        public DateTime Date { get; private set; }
        public ActionOwner Executor { get; private set; }

        public static Action FromJson(JObject jobject)
        {
            Action action = null;
            var actionTypeName = jobject.Value<string>("type");
            var actionType = typeof(Action).GetTypeInfo().Assembly.DefinedTypes
                .Where(t => t.Namespace == nameof(Tapi.TrelloEntities.Action.ActionTypes))
                .Where(t => String.Equals(t.Name, actionTypeName, StringComparison.OrdinalIgnoreCase));
            foreach (var property in action.GetType().GetProperties())
            {
                var apiPropertyName = PropertyMappings.CardFieldMappings[property.Name];
                var jToken = jobject[apiPropertyName];
                if (jToken == null) //the subclass properties are defined in the data property
                    jToken = jobject["data"][apiPropertyName];
                if (jToken != null)
                    property.SetValue(action, jToken.ToObject(property.PropertyType));
            }
            return action;
        }
    }
}
