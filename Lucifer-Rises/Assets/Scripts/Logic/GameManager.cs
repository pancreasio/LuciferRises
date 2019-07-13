using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject instance;
    public Scene currentScene;

    private void Awake()
    {
        if (!instance)
        {
            instance = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(3);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
