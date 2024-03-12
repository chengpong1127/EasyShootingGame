using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public event Action<GameResult> OnGameEnd;
    public void GameStart()
    {
        throw new NotImplementedException();
    }
}


public class GameResult{
    public string PlayerName;
	public int PlayerScore;
}