using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Card
{
    public class Card
    {
        public CardId Id { get; private set; }
        public int ShortId { get; private set; }
        public string Name { get; private set; }
        public object Description { get; private set; }
        public object DescriptionData { get; private set; }
        public bool IsClosed { get; private set; }
        public bool IsUserSubscribed { get; private set; }
        public DateTime? DueDate { get; private set; }
        public string Email { get; private set; }
        public object Badges { get; private set; }
        public IEnumerable<object> CheckItemStates { get; private set; }
        public string ContainingBoardId { get; private set; }
        public string ContainingListId { get; private set; }
        public IEnumerable<string> ContainedChecklistIds { get; private set; }
        public IEnumerable<string> MemberIds { get; private set; }
        public IEnumerable<string> VotedMemberIds { get; private set; }
        public string AttachmentCoverId { get; private set; }
        public bool ManualCoverAttachment { get; private set; }
        public IEnumerable<object> Labels { get; private set; }
        public IEnumerable<string> LabelIds { get; private set; }
        public DateTime? LastActivity { get; private set; }
        public int Position { get; private set; }
        public string Url { get; private set; }
        public string ShortUrl { get; private set; }
        public string ShortLink { get; private set; }

        public static Card FromJson(JObject jobject)
        {
            var card = new Card();
            foreach (var property in card.GetType().GetProperties())
            {
                var apiPropertyName = PropertyMappings.CardFieldMappings[property.Name];
                var jToken = jobject[apiPropertyName];
                if (jToken != null)
                    property.SetValue(card, jToken.ToObject(property.PropertyType));
            }
            return card;
        }
    }
}
