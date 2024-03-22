using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Assertions;
using Cysharp.Threading.Tasks;

public class GameRunner : MonoBehaviour
{
    [SerializeField] private TargetController targetController;
    [SerializeField] private LeaderboardController leaderboardController;
    [SerializeReference] private WeaponController weaponController;
    [SerializeField] private AudioClip gameStartSound;
    [SerializeField] private AudioClip gameEndSound;
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
        PlayerScore = 0;
        OnScoreChanged?.Invoke(PlayerScore);
        OnStartGame?.Invoke();
        targetController.OnPlayerHit += targetController_OnTargetHit;
        weaponController.OnAmmoEmpty += GameEnd;
        weaponController.AddAmmo(10);
        if (gameStartSound)
        {
            AudioManager.Instance.PlayAudio(gameStartSound, 1f);
        }
    }
    private async void GameEnd(){
        await UniTask.Delay(1000);
        OnGameEnd?.Invoke();
        targetController.OnPlayerHit -= targetController_OnTargetHit;
        leaderboardController.AddNewScore(GameManager.Instance.PlayerName, PlayerScore);
        if (gameEndSound)
        {
            AudioManager.Instance.PlayAudio(gameEndSound, 1f);
        }
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