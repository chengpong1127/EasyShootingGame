using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameTestingTool))]
public class GameTestingToolEditor : Editor
{
    private string playerName;
    private int score;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        playerName = EditorGUILayout.TextField("Player Name", playerName);
        score = EditorGUILayout.IntField("Score", score);

        if (GUILayout.Button("Input Leaderboard Data"))
        {
            LeaderboardController leaderboardController = FindObjectOfType<LeaderboardController>();
            leaderboardController.AddNewScore(playerName, score);
        }
    }
}
