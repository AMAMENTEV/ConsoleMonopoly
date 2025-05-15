using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class PenaltyCell : Cell
    {
        public int PenaltyAmount { get; }

        public PenaltyCell(string name, int penaltyAmount) : base(name)
        {
            PenaltyAmount = penaltyAmount;
        }

        public override void ExecuteAction(Player player)
        {
            player.Money -= PenaltyAmount;
            Console.WriteLine($"{player.Name} попал на {Name} и заплатил штраф {PenaltyAmount}");
        }
    }
}
