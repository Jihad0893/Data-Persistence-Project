using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public InputField nameInputField;
    public Text highScoreText;

    public GameObject warningTextObject;

    // Start is called before the first frame update
    void Start()
    {
        ShowHighScoreAndPlayerName();    
    }
    
    void ShowHighScoreAndPlayerName()
    {
        if (DataManager.Instance.playerName != "")
        {
            highScoreText.text = "Best Score: " + DataManager.Instance.playerName + " - " + DataManager.Instance.highScore;
        }
        else
        {
            highScoreText.text = "Best Score: None";
        }
    }

    public void StartGame()
    {

        if (nameInputField.text == "")
        {
            if (!warningTextObject.activeInHierarchy)
            {
                warningTextObject.SetActive(true);
            }
            return;
        }

        DataManager.Instance.nowPlayerName = nameInputField.text;
        SceneManager.LoadScene((int)GameConfigSetting.scenceList.main);
    }

    public void Exit()
    {
        DataManager.Instance.SaveHighScoreAndPlayerName();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
