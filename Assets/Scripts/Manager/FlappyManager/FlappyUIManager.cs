using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class FlappyUIManager : MonoBehaviour
{
    private static FlappyUIManager flappyUIManager;
    public static FlappyUIManager Instance { get { return flappyUIManager; } }

    public GameObject gameOverUI;
    public Text currentScoreText;
    public Text highestScoreText;

    void Start()
    {
        // process exception
        if (currentScoreText == null) Debug.LogError("Current Score Text NOT found!");
        if (highestScoreText == null) Debug.LogError("Highest Score Text NOT found!");
    }

    // Update is called once per frame
    void Update()
    {
        
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
