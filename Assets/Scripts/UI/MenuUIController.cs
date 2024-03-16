using UnityEngine;
using UnityEngine.UI;
using System;
public class MenuUIController : MonoBehaviour
{
    [SerializeField] private InputField _inputField;
    public event Action<string> OnStartGame;
    public void StartGame(){
        string playerName = _inputField.text;
        if(!string.IsNullOrEmpty(playerName)){
            OnStartGame?.Invoke(playerName);
        }
    }
}
