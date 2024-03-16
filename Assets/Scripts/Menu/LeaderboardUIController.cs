using UnityEngine;
using System;
using UnityEngine.Assertions;
public class LeaderboardUIController : MonoBehaviour
{
    [SerializeField] private LeaderboardController leaderboardController;
    void Awake(){
        Assert.IsNotNull(leaderboardController);
    }
    void Start()
    {
        leaderboardController.OnLeaderboardUpdated += LeaderboardUpdatedHandler;
    }
    private void LeaderboardUpdatedHandler()
    {
        throw new NotImplementedException();
    }
    void OnDestroy()
    {
        leaderboardController.OnLeaderboardUpdated -= LeaderboardUpdatedHandler;
    }
}