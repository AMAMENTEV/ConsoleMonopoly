using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class BonusCell : Cell
    {
        public int BonusAmount { get; }

        public BonusCell(string name, int bonusAmount) : base(name)
        {
            BonusAmount = bonusAmount;
        }

        public override void ExecuteAction(Player player)
        {
            player.Money += BonusAmount;
            Console.WriteLine($"{player.Name} попал на {Name} и получил бонус {BonusAmount}");
        }
    }
}
