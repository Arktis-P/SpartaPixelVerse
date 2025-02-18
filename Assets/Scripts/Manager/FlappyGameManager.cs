using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyGameManager : MonoBehaviour
{
    private static FlappyGameManager flappyGameManager;
    public static FlappyGameManager Instance { get { return flappyGameManager; } }

    public GameObject gameOverUI;

    private void Awake()
    {
        flappyGameManager = this;
    }

    private void Start()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        if (gameOverUI == null) Debug.LogError("GameOver UI NOT found!");
        StartCoroutine(DelayedSetActive());
    }

    IEnumerator DelayedSetActive()
    {
        yield return new WaitForSeconds(1f);  // wati for 1 sec
        gameOverUI.SetActive(true);
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
