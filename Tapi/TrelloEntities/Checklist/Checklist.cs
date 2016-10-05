using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Checklist
{
    public class Checklist
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string ContainingBoardId { get; private set; }
        public string ContainingCardId { get; private set; }
        public int Position { get; private set; }
    }
}
