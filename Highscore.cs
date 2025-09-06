using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WordShuffleGame
{
    class Highscore
    {
        private static List<Shuffle> highScores = new List<Shuffle>();
        private const string FilePath = "highscore.json";


        public void AddHighScore(string playerName, int points)
        {
            //check if the player already has a high score entry
            var existingPlayer = highScores.FirstOrDefault(s => s.PlayerName == playerName);

            if (existingPlayer != null)
            {
                //update only if the new score is higher
                if (points > existingPlayer.Points)
                {
                    existingPlayer.Points = points;
                }
            }
            else
            {
                highScores.Add(new Shuffle(playerName, points));
            }
            //highest first and show only top 5
            highScores = highScores.OrderByDescending(s => s.Points).Take(5).ToList();

            SaveHighScore();
        }


        public void DisplayScoreBoard()
        {
            Console.WriteLine("------ALL-TIME-FAVORITES------");

            int rank = 1;
            foreach (var entry in highScores)
            {
                Console.WriteLine($"----{rank}-------{entry.PlayerName}-------{entry.Points}----");
                rank++;
            }
        }

        public void SaveHighScore()
        {
            try
            {
                string json = JsonConvert.SerializeObject(highScores, Formatting.Indented);
                File.WriteAllText(FilePath, json);
                Console.WriteLine($"Highscore saved to {FilePath}");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error in saving highscores: " + ex.Message);
            }
        }

        public void LoadHighScore()
        {
            if (File.Exists(FilePath)) //check if the file exists before loading
            {
                string json = File.ReadAllText(FilePath);
                //static List<(string Player, int Score)> highscores = new List<(string, int)>();
                highScores = JsonConvert.DeserializeObject<List<Shuffle>>(json) ?? new List<Shuffle>();

                highScores = highScores.OrderByDescending(s => s.Points).Take(10).ToList();
            }
        }
    }
}
