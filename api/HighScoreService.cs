using System;
using Newtonsoft.Json;
using System.IO;

namespace spikes {

    public class HighScoreService : IHighScoreService, IDisposable {

        private HighScore CurrentHighScore;

        public HighScoreService() {
            CurrentHighScore = LoadHighScoreFromFile();
        }

        public int GetHighScore() {
            return CurrentHighScore.Score;
        }

        public int SetScore(int score) {
            
            if(score > CurrentHighScore.Score) {
                CurrentHighScore.Score = score;
            }

            SaveHighScoreToFile();

            return CurrentHighScore.Score;
        }

        private HighScore LoadHighScoreFromFile() {

            try {
                using (StreamReader file = File.OpenText(@"highScore.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return (HighScore)serializer.Deserialize(file, typeof(HighScore));
                }
            } 
            catch(Exception) {
                Console.WriteLine("HighScore.json does not exist.");    
                return new HighScore(0);
            }
        }

        private void SaveHighScoreToFile() {
            try {
                using (StreamWriter file = File.CreateText(@"highScore.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, CurrentHighScore);
                }
            }
            catch(Exception e) {
                Console.WriteLine("Error writing highscore to disk. Error is: {0}", e.ToString());    
            }
        }

        public void Dispose()
        {
            Console.WriteLine("- {0} was disposed!", this.GetType().Name);
            SaveHighScoreToFile();
        }
    }
}
