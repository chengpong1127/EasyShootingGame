using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public event Action<GameResult> OnGameEnd;
    [SerializeField] private TargetController targetController;
    private GameResult gameResult;
    public void GameStart(string playerName)
    {
        gameResult = new GameResult
        {
            PlayerName = playerName
        };
        targetController.OnPlayerHit += targetController_OnTargetHit;
    }
    private void GameEnd(){
        OnGameEnd?.Invoke(gameResult);
        targetController.OnPlayerHit -= targetController_OnTargetHit;
    }
    private void targetController_OnTargetHit(int score)
    {
        gameResult.PlayerScore += score;
    }
}


public class GameResult{
    public string PlayerName;
	public int PlayerScore;
}