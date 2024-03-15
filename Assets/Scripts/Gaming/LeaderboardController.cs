using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LeaderboardController : MonoBehaviour
{
    private List<PlayerScore> scores = new List<PlayerScore>();
    private SaveLoadManager saveLoadManager;



    void Start()
    {
        saveLoadManager = FindObjectOfType<SaveLoadManager>();// Get the data from SaveLoadManger 
        LoadLeaderboard();
    }


    public void AddNewScore(string name, int score)
    {
        var existingScore = scores.Find(s => s.Name == name);
        if (existingScore != null)
        {
            // Player already existed
            if (score > existingScore.Score)
            {
                // Renew the score
                existingScore.Score = score;
                SaveLeaderboard();
            }
        }
        else
        {
            // Add the score
            scores.Add(new PlayerScore(name, score));
            SaveLeaderboard();
        }
    }

    // Use saveLoadManager.LoadLeaderboar() to get the data
    private void LoadLeaderboard()
    {
        var loadedScores = saveLoadManager.LoadLeaderboard(); // Load data form saveLoadManager
        scores.Clear();
        // Load the all data
        foreach (var item in loadedScores)
        {
            scores.Add(new PlayerScore(item.Key, item.Value));
        }
    }

    private void SaveLeaderboard()
    {
        var leaderboardToSave = new Dictionary<string, int>();
        foreach (var score in scores)
        {
            leaderboardToSave[score.Name] = score.Score;
        }
        saveLoadManager.SaveLeaderboard(leaderboardToSave);
    }


    public List<PlayerScore> GetPlayerScoreList()
    {
        // Output after sorting scores
        return scores.OrderByDescending(s => s.Score).ToList();
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

    public void SetSaveLoadManager(SaveLoadManager manager)
    {
        this.saveLoadManager = manager;
    }
}


