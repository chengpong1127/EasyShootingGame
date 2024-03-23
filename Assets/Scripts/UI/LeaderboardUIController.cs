using UnityEngine;
using System;
using UnityEngine.Assertions;
using System.Collections.Generic;
using UnityEngine.UI;
public class LeaderboardUIController : MonoBehaviour
{
    [SerializeField] private LeaderboardController leaderboardController;
    [SerializeField] private GameRunner gameRunner;
    [SerializeField] private Text[] texts;
    void Awake(){
        Assert.IsNotNull(leaderboardController);
        Assert.IsNotNull(gameRunner);
    }
    void Start()
    {
        leaderboardController.OnLeaderboardUpdated += LeaderboardUpdatedHandler;
        gameRunner.OnStartGame += GameStartHandler;
        gameRunner.OnGameEnd += GameEndHandler;
    }
    private void LeaderboardUpdatedHandler()
    {
        List<LeaderboardController.PlayerScore> scores = leaderboardController.GetPlayerScoreList();
        for (int i = 0; i < texts.Length; i++)
        {
            if (i < scores.Count)
            {
                texts[i].text = (i + 1) + " : " + " " + scores[i].Score + " " + " " + scores[i].Name + " ";
            }
            else
            {
                texts[i].text = (i + 1) + " : " + " 0 " + " Null ";
            }
        }

    }
    void OnDestroy()
    {
        leaderboardController.OnLeaderboardUpdated -= LeaderboardUpdatedHandler;
        gameRunner.OnStartGame -= GameStartHandler;
        gameRunner.OnGameEnd -= GameEndHandler;
    }

    private void GameStartHandler()
    {
        gameObject.SetActive(false);
    }
    private void GameEndHandler()
    {
        gameObject.SetActive(true);
    }
}