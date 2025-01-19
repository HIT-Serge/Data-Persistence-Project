using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    private TMP_InputField nameInputField;
    public Text HighScoreText;

    // Start is called before the first frame update
    public void Start()
    {
        nameInputField = GameObject.Find("Name Input Field").GetComponent<TMP_InputField>();
        nameInputField.onValueChanged.AddListener(OnInputValueChanged);

             HighScoreText.text = $"Best Score: {Scene.Instance.playerName}: {Scene.Instance.highScore}";
    
       

    }

    public void StartNew()
    {
        string playerName = nameInputField.text;
        Scene.Instance.playerName = playerName;
        SceneManager.LoadScene(1);
    }

    
  

    void OnInputValueChanged(string newText) {
        Debug.Log(newText);
    }

    public void Exit() {

        Scene.Instance.SaveHighScore();
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

}
