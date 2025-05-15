using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        public string Name { get; }
        public int Money { get; set; } = 5000;
        public int Position { get; set; } = 0;

        public bool BlueMonopoly { get; set; }
        public bool RedMonopoly { get; set; }
        public bool CyanMonopoly { get; set; }
        public bool YellowMonopoly { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public bool HasMonopoly(ConsoleColor color)
        {
            if (color == ConsoleColor.Blue && BlueMonopoly == true)
            {
                return true;
            }
            if (color == ConsoleColor.Red && RedMonopoly == true)
            {
                return true;
            }
            if (color == ConsoleColor.Cyan && CyanMonopoly == true)
            {
                return true;
            }
            if (color == ConsoleColor.Yellow && YellowMonopoly == true)
            {
                return true;
            }
            return false;
        }
    }
}
