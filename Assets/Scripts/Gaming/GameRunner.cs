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
    [SerializeReference] private WeaponController weaponController;
    public event Action OnStartGame;
    public event Action<int> OnScoreChanged;
    public event Action OnGameEnd;
    public event Action OnQuitGame;
    public int PlayerScore;
    void Awake(){
        Assert.IsNotNull(targetController);
        Assert.IsNotNull(leaderboardController);
    }
    public void GameStart()
    {
        OnStartGame?.Invoke();
        targetController.OnPlayerHit += targetController_OnTargetHit;
        weaponController.OnAmmoEmpty += GameEnd;
        weaponController.AddAmmo(10);
    }
    private void GameEnd(){
        OnGameEnd?.Invoke();
        targetController.OnPlayerHit -= targetController_OnTargetHit;
        leaderboardController.AddNewScore(GameManager.Instance.PlayerName, PlayerScore);
        PlayerScore = 0;
        OnScoreChanged?.Invoke(PlayerScore);
    }
    private void targetController_OnTargetHit(int score)
    {
        PlayerScore += score;
        OnScoreChanged?.Invoke(PlayerScore);
    }
    public void QuitGame()
    {
        OnQuitGame?.Invoke();
    }
}