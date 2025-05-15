using System;

namespace Monopoly
{
    public class PropertyCell : Cell
    {
        public ConsoleColor Color { get; }
        public int Price { get; }
        public Player Owner { get; set; }
        public IPropertyUpgrade Upgrade { get; set; }



        public PropertyCell(string name, ConsoleColor color, int price) : base(name)
        {
            Color = color;
            Price = price;
            Upgrade = new NoUpgrade(this); // Начинаем без улучшений
        }

        public int GetRent()
        {
            return Upgrade.GetRent();
        }

        public override void ExecuteAction(Player player)
        {
            Console.ForegroundColor = Color;
            if (Owner == null)
            {
                if (player.Money >= Price)
                {
                    Owner = player;
                    player.Money -= Price;
                    Console.WriteLine($"{player.Name} купил {Name} за {Price}");
                }
                else
                {
                    Console.WriteLine($"{player.Name} не хватает денег для покупки {Name}");
                }
            }
            else if (Owner != player)
            {
                int rent = GetRent();
                player.Money -= rent;
                Owner.Money += rent;
                Console.WriteLine($"{player.Name} заплатил {rent} арендной платы {Owner.Name}");
            }
            else
            {
                Upgrade.TryUpgrade(player);
            }
            Console.ResetColor();
        }
    }
}