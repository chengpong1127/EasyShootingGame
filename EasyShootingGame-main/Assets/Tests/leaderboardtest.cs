using NUnit.Framework;
using UnityEngine;

public class LeaderboardControllerTests
{
    [Test]
    public void AddNewScore_UpdatesScore_IfNameAlreadyExists()
    {
        // Arrange
        var gameObject = new GameObject();
        var leaderboardController = gameObject.AddComponent<LeaderboardController>();
        var saveLoadManager = new GameObject().AddComponent<SaveLoadManager>(); // 确保你有这个类，或者用 mock 对象代替
        leaderboardController.SetSaveLoadManager(saveLoadManager);

        string playerName = "Player1";
        int initialScore = 100;
        int newScore = 200;

        // Act
        leaderboardController.AddNewScore(playerName, initialScore); 
        leaderboardController.AddNewScore(playerName, newScore); 

        var scores = leaderboardController.GetPlayerScoreList();

        // Assert
        Assert.AreEqual(1, scores.Count, "Should only contain one entry for the player.");
        Assert.AreEqual(newScore, scores[0].Score, "The player's score should be updated to the new score.");
        
        // Cleanup
        Object.DestroyImmediate(gameObject);
    }
}
