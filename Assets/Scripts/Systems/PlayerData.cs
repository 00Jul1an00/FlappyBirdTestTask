using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private const string DIFFICALT = "Difficalt";
    private const string HIGH_SCORE = "Score";
    private const string VOLUME = "Volume";

    public static PlayerData Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveDifficaltyLevel(int levelNum)
    {
        PlayerPrefs.SetInt(DIFFICALT, levelNum + 1);
        PlayerPrefs.Save();
    }

    public int GetDifficaltyLevel()
    {
        return PlayerPrefs.GetInt(DIFFICALT, 1);
    }

    public void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
        PlayerPrefs.Save();
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE, 0);
    }

    public void SaveVolume(float value)
    {
        PlayerPrefs.SetFloat(VOLUME, value);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME, 1);
    }
}
