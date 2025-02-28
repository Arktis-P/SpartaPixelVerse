using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyGameManager : MonoBehaviour
{
    private static FlappyGameManager flappyGameManager;
    public static FlappyGameManager Instance { get { return flappyGameManager; } }

    private FlappyUIManager flappyUIManager;
    public FlappyUIManager FlappyUIManager { get { return flappyUIManager; } }

    private GameManager gameManager;

    private int currentScore;
    public int CurrentScore { get => currentScore; }
    private int highestScore;
    public int HighestScore { get => highestScore; }
    // to save scores
    private const string FlappyCurrentScoreKey = "FlappyCurrentScore";
    private const string FlappyHighestScoreKey = "FlappyHighestScore";

    private bool isStart;
    public bool IsStart { get => isStart; }

    private void Awake()
    {
        flappyGameManager = this;
        flappyUIManager = FindObjectOfType<FlappyUIManager>();
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        flappyUIManager.UpdateScore(0);  // start the game with score 0
        // get highest score from player prefs
        highestScore = PlayerPrefs.GetInt(FlappyHighestScoreKey, 0);
        flappyUIManager.UpdateHighestScore(highestScore);
    }
    
    public void AddScore(int score)
    {
        currentScore += score;
        FlappyUIManager.UpdateScore(currentScore);

        // compare highest score with current score, and update if necessary
        if (currentScore > highestScore)
        {
            highestScore = currentScore;
            FlappyUIManager.UpdateHighestScore(highestScore);
            // save new highest
            PlayerPrefs.SetInt(FlappyHighestScoreKey, highestScore);
        }
    }

    public void GameOver()
    {
        // save new socres to player prefs if game ended
        PlayerPrefs.SetInt(FlappyCurrentScoreKey, currentScore);
        PlayerPrefs.SetInt(FlappyHighestScoreKey, highestScore);

        gameManager.SetPreviousScene(Scenes.FlappyGameScene);

        FlappyUIManager.RestartGame();
    }

    public void StartGame()
    {
        isStart = true;
        flappyUIManager.gameStartUI.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        // GameManager.Instance.SetPreviousScene(Scenes.FlappyGameScene);
        SceneManager.LoadScene(0);
    }
}
