using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Label
{
    public class LabelFields
    {
        public bool Id { get; private set; }
        public bool Name { get; private set; }
        public bool ContainingBoardId { get; private set; }
        public bool Color { get; private set; }
        public bool UseCount { get; private set; }

        public static readonly LabelFields All = new LabelFields
        {
            Id = true,
            Name = true,
            ContainingBoardId = true,
            Color = true,
            UseCount = true
        };
    }
}
