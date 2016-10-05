using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Notification
{
    public class NotificationFields
    {
        public bool Id { get; private set; }
        public bool Date { get; private set; }
        public bool CreatorId { get; private set; }
        public bool Type { get; private set; }
        public bool IsUnread { get; private set; }
        public bool Data { get; private set; }

        public static readonly NotificationFields All = new NotificationFields
        {
            Id = true,
            Date = true,
            CreatorId = true,
            Type = true,
            IsUnread = true,
            Data = true
        };
    }
}
