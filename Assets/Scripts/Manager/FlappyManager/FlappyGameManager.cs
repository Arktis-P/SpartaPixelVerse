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

    private int currentScore;
    public int CurrentScore { get => currentScore; }
    private int highestScore;
    public int HighestScore { get => highestScore; }

    private void Awake()
    {
        flappyGameManager = this;
        flappyUIManager = FindObjectOfType<FlappyUIManager>();
    }

    private void Start()
    {
        flappyUIManager.UpdateScore(0);  // start the game with score 0
    }
    
    public void AddScore(int score)
    {
        currentScore += score;
        FlappyUIManager.UpdateScore(currentScore);
    }

    public void GameOver()
    {
        StartCoroutine(DelayedSetActive());
    }
    IEnumerator DelayedSetActive()
    {
        yield return new WaitForSeconds(1f);  // wait for 1 sec
        FlappyUIManager.RestartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
