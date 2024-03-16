using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Assertions;

public class GameRunner : MonoBehaviour
{
    [SerializeField] private TargetController targetController;
    [SerializeField] private LeaderboardController leaderboardController;
    // IWeaponInterface weapon;
    [SerializeReference] private IWeaponInterface weapon;
    public event Action OnQuitGame;
    private int PlayerScore;
    void Awake(){
        Assert.IsNotNull(targetController);
        Assert.IsNotNull(leaderboardController);
    }
    public void GameStart()
    {
        targetController.OnPlayerHit += targetController_OnTargetHit;
        // Todo: implement the game end trigger;
    }
    private void GameEnd(){
        targetController.OnPlayerHit -= targetController_OnTargetHit;
        leaderboardController.AddNewScore(GameManager.Instance.PlayerName, PlayerScore);
        PlayerScore = 0;
    }
    private void targetController_OnTargetHit(int score)
    {
        PlayerScore += score;
    }
    public void QuitGame()
    {
        OnQuitGame?.Invoke();
    }
}