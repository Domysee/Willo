using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Board
{
    public struct BoardId
    {
        private string id;

        public BoardId(string id)
        {
            checkId(id);
            this.id = id;
        }

        public static implicit operator BoardId(string id)
        {
            return new BoardId(id);
        }

        public static implicit operator string(BoardId id)
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
