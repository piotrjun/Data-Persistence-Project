using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public int highScore;
    public string highScorePlayer;
    public string Player;
    public Text highScoreTextfield;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
            
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        LoadHighScore();
        UpdateScoreTextfield(highScoreTextfield);
    }

    [Serializable]
    class SaveData
    {
        public int highScore;
        public string highScorePlayer;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highScorePlayer = highScorePlayer;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highscore_data.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore_data.json";
        //Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            highScorePlayer = data.highScorePlayer;
        }
        else
        {
            highScore = 0;
            highScorePlayer = "";
        }
    }
    public void UpdateScoreTextfield(Text textfield)
    {
        textfield.text = "Best Score : " + highScorePlayer + " : " + highScore;
    }

}
