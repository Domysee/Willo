using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Checklist
{
    public class ChecklistFields
    {
        public bool Id { get; set; }
        public bool Name { get; set; }
        public bool ContainingBoardId { get; set; }
        public bool ContainingCardId { get; set; }
        public bool Position { get; set; }

        public static readonly ChecklistFields All = new ChecklistFields
        {
            Id = true,
            Name = true,
            ContainingBoardId = true,
            ContainingCardId = true,
            Position = true
        };
    }
}
