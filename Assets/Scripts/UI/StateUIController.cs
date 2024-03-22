using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

public class StateUIController : MonoBehaviour
{
    [SerializeField] private GameRunner gameRunner;
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private TMP_Text stateText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text ammoText;
    void Awake(){
        Assert.IsNotNull(gameRunner);
        Assert.IsNotNull(weaponController);
        Assert.IsNotNull(stateText);
        Assert.IsNotNull(scoreText);
        Assert.IsNotNull(ammoText);
    }
    void Start()
    {
        gameRunner.OnStartGame += GameStartHandler;
        gameRunner.OnGameEnd += GameEndHandler;
        gameRunner.OnScoreChanged += ScoreChangedHandler;
        weaponController.OnAmmoChanged += AmmoChangedHandler;
    }

    private void GameStartHandler()
    {
        stateText.text = "Playing...";
        scoreText.text = "Score: " + gameRunner.PlayerScore;
        ammoText.text = "AMMO: " + weaponController.AmmoCount;
    }

    private void GameEndHandler()
    {
        stateText.text = "Not Playing...";
        scoreText.text = "Score: ";
        ammoText.text = "AMMO: 0";
    }
    private void ScoreChangedHandler(int score)
    {
        scoreText.text = "Score: " + score;
    }
    private void AmmoChangedHandler(int ammo)
    {
        ammoText.text = "AMMO: " + ammo;
    }
    private void OnDestroy()
    {
        gameRunner.OnStartGame -= GameStartHandler;
        gameRunner.OnGameEnd -= GameEndHandler;
        gameRunner.OnScoreChanged -= ScoreChangedHandler;
        weaponController.OnAmmoChanged -= AmmoChangedHandler;
    }

}