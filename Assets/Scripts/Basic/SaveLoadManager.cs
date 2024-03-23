using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    private const string LeaderboardKey = "Leaderboard";

    // Save data to leaderboard
    public void SaveLeaderboard(Dictionary<string, int> leaderboard)
    {
        string json = JsonUtility.ToJson(new Serialization<string, int>(leaderboard)); // Dictionary to Json
        PlayerPrefs.SetString(LeaderboardKey, json);
        PlayerPrefs.Save();
    }

    // Load data
    public Dictionary<string, int> LoadLeaderboard()
    {
        string json = PlayerPrefs.GetString(LeaderboardKey, "{}"); // Load the data from PlayerPrefs
        var leaderboard = JsonUtility.FromJson<Serialization<string, int>>(json).ToDictionary(); // JSON to Dictionary
        return leaderboard;
    }
}

// Serialization of dictionaries 
[Serializable]
public class Serialization<TKey, TValue>
{
    [SerializeField] List<TKey> keys = new List<TKey>();
    [SerializeField] List<TValue> values = new List<TValue>();

    public Serialization(Dictionary<TKey, TValue> dict)
    {
        foreach (var kvp in dict)
        {
            keys.Add(kvp.Key);
            values.Add(kvp.Value);
        }
    }
    public Dictionary<TKey, TValue> ToDictionary()
    {
        var dict = new Dictionary<TKey, TValue>();
        for (int i = 0; i < Math.Min(keys.Count, values.Count); i++)
        {
            dict[keys[i]] = values[i];
        }
        return dict;
    }
}

