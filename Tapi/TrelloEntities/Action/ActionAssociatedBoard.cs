using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.TrelloEntities.Board;

namespace Tapi.TrelloEntities.Action
{
    public class ActionAssociatedBoard
    {
        public BoardId Id { get; set; }
        public string Name { get; set; }
        public string ShortLink { get; set; }
    }
}
