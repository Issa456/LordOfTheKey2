using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordOfTheKey
{//This Is i test
    class Game
    {
        static bool gameRunning = true;
        public static int worldWidth = 20;
        public static int worldHeight = 15;

        Room[,] rooms;
        Player player;


        public void StartGame()
        {
            CreatePlayer();
            CreateRooms();
            do
            {
                DisplayPlayerInfo();
                DisplayGameField();
                AskForCommand();

            } while (gameRunning == true);
        }

        private void DisplayPlayerInfo()
        {
            Console.WriteLine($"Player name: {player.Name}, {player.X}, {player.Y}");
        }
        private void CreateRooms()
        {
            rooms = new Room[worldWidth, worldHeight];
            Random random = new Random();

            for (int y = 0; y < worldHeight; y++)
            {
                for (int x = 0; x < worldWidth; x++)
                {
                    rooms[x, y] = new Room();
                    if (x == 0 || y == 0 || x == worldWidth - 1 || y == worldHeight - 1 || x == 13 && y != 13 || x > 13 && x != 18 && y == 7)
                    {
                        rooms[x, y].MapObjects = new Wall('#');
                    }
                    else if (x == 18 && y == 7 || x == 13 && y == 13)
                    {
                        rooms[x, y].MapObjects = new Door('D');
                    }else if (x == random.Next(1, 12) && y == random.Next(1, 13))
                    {
                        rooms[x, y].MapObjects = new Key('n');

                    }
                }

            }
        }
        private void DisplayGameField()
        {

            for (int y = 0; y < worldHeight; y++)
            {
                for (int x = 0; x < worldWidth; x++)
                {

                    if (player.X == x && player.Y == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($" {player.Symbol} ");
                        Console.ResetColor();
                    }
                    else if (rooms[x, y].MapObjects != null)
                    {
                        if (rooms[x, y].MapObjects.Symbol == 'D')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($" {rooms[x, y].MapObjects.Symbol} ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write($" {rooms[x, y].MapObjects.Symbol} ");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                Console.WriteLine();
            }


        }
        private void AskForCommand()
        {
            char command = Console.ReadKey().KeyChar;

            switch (command)
            {
                case 'a':
                    if (rooms[player.X - 1, player.Y].MapObjects == null)
                        player.X--;
                    break;
                case 'w':
                    if (rooms[player.X, player.Y - 1].MapObjects == null)
                        player.Y--;
                    break;
                case 'd':
                    if (rooms[player.X + 1, player.Y].MapObjects == null)
                        player.X++;
                    break;
                case 's':
                    if (rooms[player.X, player.Y + 1].MapObjects == null)
                        player.Y++;
                    break;
            }
            Console.Clear();
        }

        private string CreatePlayer()
        {
            Console.WriteLine("Hello, enter your name: ");
            string playerName = Console.ReadLine();

            player = new Player(playerName, 100, '@', 10, 10);
            Console.Clear();
            return playerName;
        }

    }
}
