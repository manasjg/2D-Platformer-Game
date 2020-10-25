using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    [SerializeField]
    string[] Levels;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt(Levels[0], (int)LevelState.Unlocked) == (int)LevelState.Locked)
        {
            PlayerPrefs.SetInt(Levels[0], (int)LevelState.Unlocked);
        }
    }

    public void MarkCurrentLevelAsComplete()
    {
        Scene currScene = SceneManager.GetActiveScene();
        int index = Array.FindIndex(Levels, level => level == currScene.name);
        SetLevelStatus(currScene.name, LevelState.Completed);
        LoadNextScene(index);
    }

    void LoadNextScene(int currIndex)
    {
        if (currIndex + 1 < Levels.Length)
        {
            SetLevelStatus(Levels[currIndex + 1], LevelState.Unlocked);
            SceneManager.LoadScene(currIndex + 2);
        }
    }

    public LevelState GetLevelStatus(string LevelName)
    {
        return (LevelState)PlayerPrefs.GetInt(LevelName);
    }
    public void SetLevelStatus(string LevelName, LevelState state)
    {
        PlayerPrefs.SetInt(LevelName, (int)state);
    }
}
