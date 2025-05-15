using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Game
    {
        private Player player1;
        private Player player2;

        public List<Cell> cells;
        private Random random;

        private Dictionary<Player, bool> skipTurn;

        public Game()
        {
            player1 = new Player("Игрок 1");
            player2 = new Player("Игрок 2");

            cells = new List<Cell>
            {
            new BonusCell("Клетка СТАРТ", 100),

            new PropertyCell("Синий 1", ConsoleColor.Blue, 100),
            new PropertyCell("Зеленый 1", ConsoleColor.Green, 200),
            new PenaltyCell("Штрафная клетка 1", 150),
            new PropertyCell("Красный 1", ConsoleColor.Red, 300),
            new BonusCell("Бонусная клетка 1", 100),
            new JailCell("Тюрьма 1"),
            new PropertyCell("Желтый 1", ConsoleColor.Yellow, 200),
            new PropertyCell("Циан 1", ConsoleColor.Cyan, 100),

            new PropertyCell("Синий 2", ConsoleColor.Blue, 200),
            new PropertyCell("Зеленый 2", ConsoleColor.Green, 400),
            new PenaltyCell("Штрафная клетка 2", 300),
            new PropertyCell("Красный 2", ConsoleColor.Red, 600),
            new BonusCell("Бонусная клетка 2", 200),
            new JailCell("Тюрьма 2"),
            new PropertyCell("Желтый 2", ConsoleColor.Yellow, 300),
            new PropertyCell("Циан 2", ConsoleColor.Cyan, 100),

            new PropertyCell("Синий 3", ConsoleColor.Blue, 300),
            new PropertyCell("Зеленый 3", ConsoleColor.Green, 500),
            new PenaltyCell("Штрафная клетка 3", 400),
            new PropertyCell("Красный 3", ConsoleColor.Red, 700),
            new BonusCell("Бонусная клетка 3", 500),
            new JailCell("Тюрьма 3"),
            new PropertyCell("Желтый 3", ConsoleColor.Yellow, 500),
            new PropertyCell("Циан 3", ConsoleColor.Cyan, 100)
            };

            random = new Random();
            skipTurn = new Dictionary<Player, bool>
            {
                [player1] = false,
                [player2] = false
            };
        }

        public void Start()
        {
            while (player1.Money > 0 && player2.Money > 0)
            {
                TakeTurn(player1);
                Console.WriteLine("\n");

                TakeTurn(player2);
                Console.WriteLine("\n");

                PrintStatus();
                Console.WriteLine("\n" + ">------------------------------------<" + "\n");

            }

            DeclareWinner();
        }

        private void TakeTurn(Player player)
        {
            if (skipTurn[player])
            {
                Console.WriteLine($"{player.Name} пропускает ход.");
                skipTurn[player] = false; // Пропускаем ход один раз
                return;
            }

            int diceRoll = random.Next(1, 7); // Бросок кубика (1-6)
            player.Position = (player.Position + diceRoll) % cells.Count;

            Cell cell = cells[player.Position];
            Console.WriteLine($"{player.Name} бросил {diceRoll} и попал на {cell.Name}");

            if (cell is JailCell)
            {
                skipTurn[player] = true; // Пропускаем следующий ход, если тюрьма
            }

            cell.ExecuteAction(player);

            if (cell is PropertyCell propertyCell && propertyCell.Owner != null)
            {
                HasMonopoly(player, propertyCell.Color);
            }
        }

        private void PrintStatus()
        {
            Console.WriteLine($"{player1.Name}: {player1.Money} денег, на {cells[player1.Position].Name}");
            Console.WriteLine($"{player2.Name}: {player2.Money} денег, на {cells[player2.Position].Name}");
            Console.WriteLine("\n");

            for (int i = 0; i < cells.Count; i++)
            {
                PropertyCell propertyCell = cells[i] as PropertyCell;
                if (propertyCell != null)
                {
                    Console.ForegroundColor = propertyCell.Color;
                    if (propertyCell.Owner != null)
                        Console.WriteLine($"{propertyCell.Name} владеет {propertyCell.Owner.Name} и улучшил на {propertyCell.Upgrade.GetLvl()}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        private void DeclareWinner()
        {
            if (player1.Money <= 0)
                Console.WriteLine("Победитель: Игрок 2!");
            else
                Console.WriteLine("Победитель: Игрок 1!");

            WaitForSpace();
        }
        private void WaitForSpace()
        {
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            }
            while (key.Key != ConsoleKey.Spacebar);

            Environment.Exit(0); // Завершаем программу после нажатия пробела
        }

        public void HasMonopoly(Player player, ConsoleColor color)
        {
            int ownedCount = 0;

            foreach (var cell in cells)
            {
                if (cell is PropertyCell propertyCell && propertyCell.Color == color)
                {
                    
                    if (propertyCell.Owner != null && propertyCell.Owner == player)
                    {
                        ownedCount++;
                    }
                }
            }

            // Если игрок владеет всеми свойствами этого цвета
            if (ownedCount == 3)
            {
                switch (color)
                {
                    case ConsoleColor.Blue:
                        player.BlueMonopoly = true;
                        break;
                    case ConsoleColor.Red:
                        player.RedMonopoly = true;
                        break;
                    case ConsoleColor.Cyan:
                        player.CyanMonopoly = true;
                        break;
                    case ConsoleColor.Yellow:
                        player.YellowMonopoly = true;
                        break;
                }
                
            }
        }
    
        }
    }

