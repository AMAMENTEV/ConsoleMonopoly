using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Cell
    {
        public string Name { get; }

        protected Cell(string name)
        {
            Name = name;
        }

        public abstract void ExecuteAction(Player player);
    }
}
