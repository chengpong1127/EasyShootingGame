using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
public class GameManager: Singleton<GameManager>{
    public string PlayerName { get; private set; }
    private GameRunner _gameRunner;
    void Start(){
        DontDestroyOnLoad(gameObject);
    }
    public async void StartGame(string playerName){
        PlayerName = playerName;
        await SceneManager.LoadSceneAsync("Game");
        _gameRunner = FindObjectOfType<GameRunner>();
        _gameRunner.OnQuitGame += QuitGameHandler;
    }
    private async void QuitGameHandler(){
        _gameRunner.OnQuitGame -= QuitGameHandler;
        _gameRunner = null;
        await SceneManager.LoadSceneAsync("MenuScene");
    }
}