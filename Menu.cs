using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordShuffleGame
{
    class Menu
    {
        Highscore highscore = new Highscore();
        GameLoop gameLoop = new GameLoop();
        Shuffle shuffle = new Shuffle();
        
        public void GameMenu()
        {
            Console.CursorVisible = false;
            int selectedIndex = 0;
            bool menuLoop = true;

            string[] menuOptions = new string[]

            {
            "Game rules",
            "Let's play!",
            "Highscores",
            "Exit",
            };

            while (menuLoop)
            {
                Console.Clear();
                StartFont();
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($" > {menuOptions[i]} < ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   {menuOptions[i]}");
                    }
                }
                Console.ResetColor();

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    if (selectedIndex == 0)
                    {
                        selectedIndex = menuOptions.Length - 1;
                    }
                    else
                    {
                        selectedIndex--;
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {

                    if (selectedIndex == menuOptions.Length - 1)
                    {
                        selectedIndex = 0;
                    }
                    else
                    {
                        selectedIndex++;
                    }
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (selectedIndex == 0)
                    {
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("A list of words will be shown.");
                        Console.WriteLine("Try to remember them as best as possible.");
                        Console.WriteLine("Then they will be deleted.");
                        Console.WriteLine("Then a random word will be picked and shuffled.");
                        Console.WriteLine("Then you have to guess the right word.");
                        Console.WriteLine("---------------------------------------------------");
                    }
                    else if (selectedIndex == 1)
                    {
                        gameLoop.GameStart();
                    }
                    else if (selectedIndex == 2)
                    {
                        highscore.LoadHighScore();
                        highscore.DisplayScoreBoard();
                    }
                    else if (selectedIndex == 3)
                    {
                        Console.WriteLine("Goodbye.. maybe until later :)");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");

                    }
                    Console.WriteLine($"You have selected {menuOptions[selectedIndex]}");
                    Console.ReadKey();       
                }
            }
        }

        public static void StartFont()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string message = ("\r\n██     ████████████████████     ████████   ███    ███████████████    ███████     ██████ ████████    █████████ \r\n██     ███    ███   ███   ██    ██    ██   ███    ███    ██    ██    ██         ██     ██   █████  █████      \r\n██  █  ███    █████████   ██    ██████████████    ██████ █████ ██    █████      ██   ██████████ ████ ██████   \r\n██ ███ ███    ███   ███   ██         ███   ███    ███    ██    ██    ██         ██    ███   ███  ██  ███      \r\n ███ ███ ████████   ███████     ████████   ██████████    ██    █████████████     ████████   ███      ████████ \r\n                                                                                                              \r\n                                                                                                              \r\n");
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
