using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class JailCell : Cell
    {
        public JailCell(string name) : base(name) { }

        public override void ExecuteAction(Player player)
        {
            Console.WriteLine($"{player.Name} попал в тюрьму и пропускает следующий ход.");
        }
    }
}
