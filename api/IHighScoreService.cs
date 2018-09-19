using System;

namespace spikes {

    public interface IHighScoreService 
    {
        int GetHighScore ();

        int SetScore(int score);

    }
}
