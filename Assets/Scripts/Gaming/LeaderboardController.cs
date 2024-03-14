using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Ling;

public class LeaderboardController : MonoBehaviour
{
    private List<PlayerScore> scores = new List<PlayerScore>();

    public void AddNewScore(string name, int score)
    {
        // Check to see if the name already exists
        if (!NameExists(name))
        {
            scores.Add(new PlayerScore(name, score));

            // Sort scores
            scores = scores.OrderByDescending(s => s.score).ToList();
        }
        else //If the name already exists
        {   
            var existingScore = scores.Find(s => s.name == name);
            if (score > existingScore.score)
            {
                existingScore.score = score;
            }
         }

    }   

    public bool NameExists(string name)
    {
        return scores.Any(s => s.name == name);
    }


