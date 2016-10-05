using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
