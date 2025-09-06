using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordShuffleGame
{
    class GameLoop
    {
        Shuffle shuffle = new Shuffle();
        bool gameLoop = false;
        string userChoice; 

        public void GameStart()
        {
            Console.WriteLine("Enter your name: ............");
            shuffle.PlayerName = Console.ReadLine();
            shuffle.ResetWords();
            Console.WriteLine($"Welcome {shuffle.PlayerName} Let's go!");
            //shuffle.AddHighScore(shuffle.PlayerName, shuffle.Points);
            shuffle.ListList();

            while (!gameLoop)
            {
                userChoice = "";
                shuffle.ListList();

                Console.WriteLine("Play more? (Enter) or do you want to give up? (Q)");
                userChoice = Console.ReadLine().ToUpper();

                if (userChoice == "Q")
                {
                    gameLoop = true;
                }
                else
                {
                    Console.WriteLine("Here we go..");
                    Console.Clear();
                }
            }
            Console.WriteLine("You got: " + shuffle.Points + " Points");
        }
    }
}
