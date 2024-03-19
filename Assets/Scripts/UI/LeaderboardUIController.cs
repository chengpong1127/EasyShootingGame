using UnityEngine;
using System;
using UnityEngine.Assertions;
using System.Collections.Generic;
using UnityEngine.UI;
public class LeaderboardUIController : MonoBehaviour
{
    [SerializeField] private LeaderboardController leaderboardController;
    [SerializeField] private Text[] texts;
    void Awake(){
        Assert.IsNotNull(leaderboardController);
    }
    void Start()
    {
        leaderboardController.OnLeaderboardUpdated += LeaderboardUpdatedHandler;
    }
    private void LeaderboardUpdatedHandler()
    {
        List<LeaderboardController.PlayerScore> scores = leaderboardController.GetPlayerScoreList();
        for (int i = 0; i < texts.Length; i++)
        {
            if (i < scores.Count)
            {
                texts[i].text = scores[i].Name + " : " + scores[i].Score;
            }
            else
            {
                texts[i].text = "";
            }
        }

    }
    void OnDestroy()
    {
        leaderboardController.OnLeaderboardUpdated -= LeaderboardUpdatedHandler;
    }
}