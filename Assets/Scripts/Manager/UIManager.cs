using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject miniResultUI;
    public Text scoreText;

    private const string CurrentScoreKey = "CurrentScore";
    private const string HighestScoreKey = "HighestScore";

    private GameManager gameManager;
    private static UIManager uiManager;
    public static UIManager Instance { get { return uiManager; } }

    private void Start()
    {
        gameManager = GameManager.Instance;
        uiManager = this;
        gameManager.uiManager = this;
    }

    // show resultUI if previous scene is minigame
    public void ShowResultUI()
    {
        if (gameManager.PreviousScene != Scenes.FlappyGameScene) return;
        else
        {
            // show mini result ui
            UpdateResultUI();
            miniResultUI.SetActive(true);
            // erase previous scene
            gameManager.SetPreviousScene(Scenes.MainScene);
        }
    }
    private void UpdateResultUI()
    {
        scoreText.text = $"현재 기록: {PlayerPrefs.GetInt(CurrentScoreKey, 0)}\n최고 기록: {PlayerPrefs.GetInt(HighestScoreKey, 0)}";
    }
    public void DeleteResultUI()
    {
        miniResultUI.SetActive(false);
    }
}
