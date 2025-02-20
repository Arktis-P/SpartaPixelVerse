using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum NPCNames
{
    FlappyGuide, LeaderboardGuide
}

public class UIManager : MonoBehaviour
{
    public GameObject miniResultUI;
    public Text scoreText;

    private const string FlappyCurrentScoreKey = "FlappyCurrentScore";
    private const string FlappyHighestScoreKey = "FlappyHighestScore";

    public GameObject flappyGuideDesc;

    public GameObject leaderboardGuideDesc;
    public GameObject leaderboardUI;
    public Text leaderboardScoreText;
    private bool isLeaderboard = false;

    public GameObject closetChestDesc;
    public GameObject closetUI;
    private bool isCloset = false;

    public GameObject petChestDesc;

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
        scoreText.text = $"현재 기록: {PlayerPrefs.GetInt(FlappyCurrentScoreKey, 0)}\n최고 기록: {PlayerPrefs.GetInt(FlappyHighestScoreKey, 0)}";
    }
    public void DeleteResultUI()
    {
        miniResultUI.SetActive(false);
    }

    // show npc names and their decriptions
    public void ShowFlappyGuideDesc(bool isInside)
    {
        flappyGuideDesc.SetActive(isInside);
    }
    public void ShowLeaderboardGuideDesc(bool isInside)
    {
        leaderboardGuideDesc.SetActive(isInside);
    }
    public void ShowClosetChestDesc(bool isInside)
    {
        closetChestDesc.SetActive(isInside);
    }
    public void ShowPetChestDesc(bool isInside)
    {
        petChestDesc.SetActive(isInside);
    }

    // methods about leaderboard
    private void UpdateLeaderboard()
    {
        string str = "";
        str += PlayerPrefs.GetInt(FlappyHighestScoreKey, 0);

        leaderboardScoreText.text = str;
    }
    public void ShowLeaderboard()
    {
        isLeaderboard = !isLeaderboard;
        UpdateLeaderboard();
        leaderboardUI.SetActive(isLeaderboard);
    }
    
    // methods for closet
    public void ShowCloset()
    {
        isCloset = !isCloset;
        closetUI.SetActive(isCloset);
    }
}
