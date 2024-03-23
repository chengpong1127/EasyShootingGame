using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class LeaderboardController : MonoBehaviour
{
    private List<PlayerScore> scores = new List<PlayerScore>();
    public event Action OnLeaderboardUpdated = delegate { };
    private SaveLoadManager saveLoadManager;

    void Start()
    {
        saveLoadManager = FindObjectOfType<SaveLoadManager>();// Get the data from SaveLoadManger 
        LoadLeaderboard();
    }


    public void AddNewScore(string name, int score)
    {   
        bool needsUpdate = false;
        var existingScore = scores.Find(s => s.Name == name);
        if (existingScore != null)
        {
            // Player already existed
            if (score > existingScore.Score)
            {
                // Renew the score
                existingScore.Score = score;
                needsUpdate = true;
                SaveLeaderboard();
            }
        }
        else
        {
            // Add the score
            scores.Add(new PlayerScore(name, score));
            needsUpdate = true;
            SaveLeaderboard();
        }

        if (needsUpdate)
        {
            SaveLeaderboard();
            OnLeaderboardUpdated.Invoke(); // Invoke the event after the leaderboard is updated
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
            OnLeaderboardUpdated.Invoke(); // Invoke the event after scores are loaded and list is potentially updated
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

    public void ClearLeaderboard()
{
    scores.Clear(); // clear the scores
    SaveLeaderboard(); // save the leaderboard
    OnLeaderboardUpdated.Invoke(); // Invoke the event after the leaderboard is updated
}

}


