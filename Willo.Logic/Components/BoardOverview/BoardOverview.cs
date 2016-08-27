using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic.Components.BoardOverview
{
    public class BoardOverview
    {
        public string Id { get; }
        public string Name { get; }

        public BoardOverview(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
