using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Ling;

public class LeaderboardController : MonoBehaviour
{
    private List<PlayerScore> scores = new List<PlayerScore>();

    public void AddNewScore(string name, int score)
    {
        // 檢查檢查該名稱是否已經存在於排行榜中
        if (!NameExists(name))
        {
            scores.Add(new PlayerScore(name, score));

            // 對分數進行排序
            scores = scores.OrderByDescending(s => s.score).ToList();
        }
        else //如果名子存在，會更新數值
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


