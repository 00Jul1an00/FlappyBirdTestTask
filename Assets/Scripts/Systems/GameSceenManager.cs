using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class GameSceenManager : MonoBehaviour
{
    [SerializeField] private AudioClip _clipBetweenSceens;

    public static GameSceenManager Instance { get; private set; }

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

    public void LoadMainMenuSceen()
    {
        StartCoroutine(WaitForClipEnds(_clipBetweenSceens.length, 0));
    }

    public void LoadChosenLevel()
    {
        StartCoroutine(WaitForClipEnds(_clipBetweenSceens.length, PlayerData.Instance.GetDifficaltyLevel())); 
    }

    private IEnumerator WaitForClipEnds(float t, int level)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(level);
    }
}
