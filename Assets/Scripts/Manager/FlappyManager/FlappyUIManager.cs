using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class FlappyUIManager : MonoBehaviour
{
    private static FlappyUIManager flappyUIManager;
    public static FlappyUIManager Instance { get { return flappyUIManager; } }

    public GameObject gameStartUI;
    public GameObject gameOverUI;
    public Text currentScoreText;
    public Text highestScoreText;

    void Start()
    {
        // process exception
        if (gameStartUI == null) Debug.LogError("Game Start UI NOT found!");
        if (gameOverUI == null) Debug.LogError("Game Over UI NOT found!");
        if (currentScoreText == null) Debug.LogError("Current Score Text NOT found!");
        if (highestScoreText == null) Debug.LogError("Highest Score Text NOT found!");
    }

    public void StartGame()
    {
        gameStartUI.SetActive(true);
    }

    public void RestartGame()
    {
        gameOverUI.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        currentScoreText.text = score.ToString();
    }
    public void UpdateHighestScore(int score)
    {
        highestScoreText.text = score.ToString();
    }
}
