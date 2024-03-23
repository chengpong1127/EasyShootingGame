using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Assertions;
using TMPro;
public class MenuUIController : MonoBehaviour
{
    [SerializeField] private  TMP_InputField _inputField;
    private TouchScreenKeyboard _keyboard;
    void Awake(){
        Assert.IsNotNull(_inputField);
    }
    public void StartGame(){
        GameManager.Instance.StartGame(_inputField.text);
    }
    public void QuitGame(){
        GameManager.Instance.QuitGame();
    }
    public void ShowKeyboard(){
        _keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}
