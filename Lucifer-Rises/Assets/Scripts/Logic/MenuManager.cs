﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private GameManager gameManager;
    public Text scoreText;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.UpdateCurrent();
        if (scoreText != null)
        {
            scoreText.text = "Final Score: " + GameManager.score;
        }
        Cursor.visible = true;
    }


    public void Menu()
    {
        gameManager.Menu();
    }

    public void Retry()
    {
        gameManager.Retry();
    }

    public void StartGame()
    {
        GameManager.score = 0;
        gameManager.NextScene();
    }

    public void Exit()
    {
        gameManager.ExitGame();
    }
}
