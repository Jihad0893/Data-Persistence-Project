using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName = "";
    public int highScore = 0;

    public string nowPlayerName = "";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);

        LoadHighScoreAndPlayerName();
    }


    [System.Serializable]
    class SaveData
    {
        public int highScore = 0;
        public string playerName = "";
    }

    public void LoadHighScoreAndPlayerName()   //  format: Alexandar-100
    {
        string path = Application.dataPath + "/save.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScore = data.highScore;
        }
    }

    public void SaveHighScoreAndPlayerName()
    {
        if (highScore > 0)
        {
            playerName = nowPlayerName;

            SaveData data = new SaveData();
            data.highScore = highScore;
            data.playerName = playerName;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.dataPath + "/save.json", json);
        }
    }


}
