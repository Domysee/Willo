using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic.BoardOverview
{
    public class OverviewBoard
    {
        public string Id { get; }
        public string Name { get; }

        public OverviewBoard(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
