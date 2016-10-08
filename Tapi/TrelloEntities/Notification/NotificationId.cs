using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Notification
{
    public struct NotificationId
    {
        private string id;

        public NotificationId(string id)
        {
            checkId(id);
            this.id = id;
        }

        public static implicit operator NotificationId(string id)
        {
            return new NotificationId(id);
        }

        public static implicit operator string(NotificationId id)
        {
            return id.id;
        }

        private static void checkId(string id)
        {

        }

        public override string ToString()
        {
            return id;
        }
    }
}
