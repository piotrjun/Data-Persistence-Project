using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public int highScore = 0;
    public string highScorePlayer = "John";
    public string Player;
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

}
