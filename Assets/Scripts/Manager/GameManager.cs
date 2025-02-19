using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    string previousScene;
    public string PreviousScene { get => previousScene; }

    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    private void Awake()
    {
        gameManager = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetPreviousScene(string scene)
    {
        previousScene = scene;
    }
}
