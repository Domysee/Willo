using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.List
{
    public class ListFields
    {
        public bool Id { get; private set; }
        public bool Name { get; private set; }
        public bool IsClosed { get; private set; }
        public bool IsUserSubscribed { get; private set; }
        public bool ContainingBoardId { get; private set; }
        public bool Position { get; private set; }

        public static readonly ListFields All = new ListFields
        {
            Id = true,
            Name = true,
            IsClosed = true,
            IsUserSubscribed = true,
            ContainingBoardId = true,
            Position = true
        };
    }
}
