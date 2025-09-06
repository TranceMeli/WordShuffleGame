using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace WordShuffleGame
{
    class Shuffle
    {
        Highscore highscore = new Highscore();
        private static Random random = new Random();
        int mistakes;
        int points;
        int count;
        string playerName;
        List<string> words;

        public string PlayerName { get => playerName; set => playerName = value; }

        public int Mistakes { get => mistakes; set => mistakes = value; }
        public int Points { get => points; set => points = value; }
        public List<string> Words { get => words; set => words = value; }
        public int Count { get => count; set => count = value; }

        public Shuffle()
        {
            
            Words = new List<string>();

            Words.Add("Pizza");
            Words.Add("Sushi");
            Words.Add("Burgers");
            Words.Add("Tacos");
            Words.Add("Pasta");
            Words.Add("Dim Sum");
            Words.Add("Paella");
            Words.Add("Curry");
            Words.Add("Croissants");
            Words.Add("Peking Duck");
            Words.Add("Ramen");
            Words.Add("Biryani");
            Words.Add("Falafel");
            Words.Add("Chow Mein");
            Words.Add("Donuts");
            Words.Add("Gyros");
            Words.Add("Steak");
            Words.Add("Pho");
            Words.Add("Lasagna");
            Words.Add("Pancakes");
            Words.Add("Samosa");
            Words.Add("Cheesecake");
            Words.Add("Dumplings");
            Words.Add("Goulash");
            Words.Add("Pierogi");
            Words.Add("Hot Dog");
            Words.Add("Bruschetta");
            Words.Add("Quiche");
            Words.Add("Fajitas");
            Words.Add("Hummus");
            Words.Add("Clam Chowder");
            Words.Add("Gelato");
            Words.Add("Kimchi");
            Words.Add("Gnocchi");
            Words.Add("Moussaka");
            Words.Add("Schnitzel");
            Words.Add("Ceviche");
            Words.Add("Tamales");
            Words.Add("Macarons");
            Words.Add("Bibimbap");
            Words.Add("Churros");
            Words.Add("Shawarma");
            Words.Add("Crepes");
            Words.Add("Kabobs");
            Words.Add("Couscous");
            Words.Add("Poutine");
            Words.Add("Baklava");
            Words.Add("Jambalaya");
            Words.Add("Empanadas");
            Words.Add("Lobster Roll");
        }

    
        public Shuffle(string playerName, int points)
        {
            this.playerName = playerName;
            this.points = points;
        }

        public void ShuffleList(List<string> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }

        public void ListList()
        {
            //mistakes = 0;
            points = 0;
            Shuffle words = new Shuffle();
            count = 1;

            var randomNumbers =  Words.OrderBy(x => random.Next()).Take(10);

            foreach (string chosenList in randomNumbers)
            {
                Console.WriteLine($"{count}: {chosenList}");
                count++;
                Thread.Sleep(500);
            }

            //Console.WriteLine("The list will be deleted shortly..");
            Thread.Sleep(1000);
            Words.Clear();
            
            Console.WriteLine("List deleted!");
            Console.Clear();

            string randomWord = words.Words[random.Next(words.Words.Count)];
            string randomizedWord = RandomizeCharactersandCase(randomWord);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"The shuffled random word from is: {randomizedWord}");
            Console.ResetColor();

            Console.WriteLine("Please enter the original word");
            string userInput = Console.ReadLine();
            
            //DisplayScoreBoard();

            bool areEqual = randomWord.Equals(userInput, StringComparison.Ordinal);

            if (areEqual)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct");
                points +=10;
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect");
                mistakes++;
                Console.ResetColor();
            }
            highscore.AddHighScore(playerName, points);
            MistakesShow();
            
        }

        public static string RandomizeCharactersandCase(string input, bool randomizeCase = true)
        {
            char[] array = input.ToCharArray();

            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }

            if (randomizeCase)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = random.Next(2) == 0 ? char.ToLower(array[i]) : char.ToUpper(array[i]);
                }
            }
            return new string(array);
        }

        public void MistakesShow()
        {
            switch (mistakes)
            {
                case 1:
                    Console.WriteLine("X");
                    break;
                case 2:
                    Console.WriteLine("X_X");
                break;
                case 3:
                    Console.WriteLine("X_X_X");
                break;
                case 4:
                    Console.WriteLine("X_X_X_X");
                break;
                case 5:
                    Console.WriteLine("X_X_X_X_X");
                    Console.WriteLine("GAME OVER!!!");
                    Environment.Exit(0);
                    break;
            }
        }
        public void ResetWords()
        {
            Words = new List<string>();

            Words.Add("Pizza");
            Words.Add("Sushi");
            Words.Add("Burgers");
            Words.Add("Tacos");
            Words.Add("Pasta");
            Words.Add("Dim Sum");
            Words.Add("Paella");
            Words.Add("Curry");
            Words.Add("Croissants");
            Words.Add("Peking Duck");
            Words.Add("Ramen");
            Words.Add("Biryani");
            Words.Add("Falafel");
            Words.Add("Chow Mein");
            Words.Add("Donuts");
            Words.Add("Gyros");
            Words.Add("Steak");
            Words.Add("Pho");
            Words.Add("Lasagna");
            Words.Add("Pancakes");
            Words.Add("Samosa");
            Words.Add("Cheesecake");
            Words.Add("Dumplings");
            Words.Add("Goulash");
            Words.Add("Pierogi");
            Words.Add("Hot Dog");
            Words.Add("Bruschetta");
            Words.Add("Quiche");
            Words.Add("Fajitas");
            Words.Add("Hummus");
            Words.Add("Clam Chowder");
            Words.Add("Gelato");
            Words.Add("Kimchi");
            Words.Add("Gnocchi");
            Words.Add("Moussaka");
            Words.Add("Schnitzel");
            Words.Add("Ceviche");
            Words.Add("Tamales");
            Words.Add("Macarons");
            Words.Add("Bibimbap");
            Words.Add("Churros");
            Words.Add("Shawarma");
            Words.Add("Crepes");
            Words.Add("Kabobs");
            Words.Add("Couscous");
            Words.Add("Poutine");
            Words.Add("Baklava");
            Words.Add("Jambalaya");
            Words.Add("Empanadas");
            Words.Add("Lobster Roll");
        }  
    }
}
