using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameObject instance;
    public Scene currentScene;
    public static int score;
    private int lastPlayedLevelIndex;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
            currentScene = SceneManager.GetActiveScene();
            lastPlayedLevelIndex = currentScene.buildIndex;
            score = 0;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void ReloadScene()
    {
        Wave.deadEnemies = 0;
        Wave.totalSpawnedEnemies = 0;
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void NextScene()
    {
        Wave.deadEnemies = 0;
        Wave.totalSpawnedEnemies = 0;
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void GameOver()
    {
        Wave.deadEnemies = 0;
        Wave.totalSpawnedEnemies = 0;
        SceneManager.LoadScene(3);
        currentScene = SceneManager.GetSceneByBuildIndex(3);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        currentScene = SceneManager.GetSceneByBuildIndex(0);
    }

    public void UpdateCurrent()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetRetryLevel()
    {
        lastPlayedLevelIndex = currentScene.buildIndex;
    }

    public void Retry()
    {
        Wave.deadEnemies = 0;
        Wave.totalSpawnedEnemies = 0;
        SceneManager.LoadScene(lastPlayedLevelIndex);
        score = 0;
    }
}
