using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase;
using CodeBase.Player;
using CodeBase.UI;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private EnemyGeneration enemyGeneration;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

   
    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
        RayCastSwitchGameOverUi(true);
    }
    
    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.ResetButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.ResetButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        enemyGeneration.RestPool();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.ResetPlayer();
    }

    private void RayCastSwitchGameOverUi(bool isActive)
    {
        foreach (var image in _gameOverScreen.GetComponentsInChildren<Image>())
        {
            image.raycastTarget = isActive;
        }
    }
}
