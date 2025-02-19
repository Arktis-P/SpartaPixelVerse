using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    MainScene, FlappyGameScene
}

public class GameManager : MonoBehaviour
{
    private Scenes previousScene;
    public Scenes PreviousScene { get => previousScene; }

    private static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    public static UIManager uiManager;

    private void Awake()
    {
        if (Instance == null)
        {
            gameManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        previousScene = Scenes.MainScene;
    }

    private void Update()
    {
        if (previousScene != (Scenes)(SceneManager.GetActiveScene().buildIndex) && previousScene == Scenes.FlappyGameScene)
            uiManager.ShowResultUI();
    }

    public void SetPreviousScene(Scenes scene)
    {
        previousScene = scene;
    }
}
