using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
    public Text highScoreText;

    public MainManager mainManager;

    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();

        InitiateHighScoreAndPlayerName();
    }

    void InitiateHighScoreAndPlayerName()
    {
        if (DataManager.Instance.highScore > 0)
        {
            RefreshHighScoreAndPlayerName();
        }
        else
        {
            highScoreText.text = "Best Score : None";
        }
    }

    public void RefreshHighScoreAndPlayerName()
    {
        //  format:  Best Score : Name : 0
        highScoreText.text = "Best Score : " + DataManager.Instance.playerName + " - " + DataManager.Instance.highScore;
    }

    public void ReturnTitle()
    {
        if (!mainManager.IsGameStart())
        {
            SceneManager.LoadScene((int)GameConfigSetting.scenceList.menu);
        }
        else
        {
            GameObject warningTextObj = transform.Find("WarningText").gameObject;
            if (!warningTextObj.activeInHierarchy)
            {
                warningTextObj.SetActive(true);
            }
        }
    }
}
