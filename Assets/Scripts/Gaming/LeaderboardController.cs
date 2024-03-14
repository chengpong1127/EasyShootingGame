using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class LeaderboardController : MonoBehaviour
{
    // LIst of players
    private List<PlayerScore> scores = new List<PlayerScore>();

    // AddNewScore
    public void AddNewScore(string name, int score)
    {
        // Check to see if the name already exists
        if (!NameExists(name))
        {
            scores.Add(new PlayerScore(name, score));

            // Sort scores
            scores = scores.OrderByDescending(s => s.Score).ToList();
        }
        else //If the name already exists
        {
            var existingScore = scores.Find(s => s.Name == name);
            if (score > existingScore.Score)
            {
                existingScore.Score = score;
            }
        }

    }

    
    public bool NameExists(string name)
    {
        return scores.Any(s => s.Name == name);

    }

    // Public Scores record
    public List<PlayerScore> Scores
    {
        get { return scores; }
    }

    
    public class PlayerScore
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public PlayerScore(string name, int score)
        {
            Name = name;
            Score = score;
        }

    }

}
