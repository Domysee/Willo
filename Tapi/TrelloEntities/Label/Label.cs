using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Label
{
    public class Label
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string ContainingBoardId { get; private set; }
        public string Color { get; private set; }
        public int UseCount { get; private set; }
    }
}
