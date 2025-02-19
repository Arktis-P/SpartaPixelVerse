using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderboardGuideButtonHandler : MonoBehaviour
{
    public GameObject interactButton;
    private bool isInside = false;  // check if player is in its collider area

    private const string FlappyHighestScoreKey = "FlappyHighestScore";

    private void Start()
    {
        // initialize interact button
        if (interactButton == null) return;
        interactButton.SetActive(false);
    }

    private void Update()
    {
        if (isInside && Input.GetKeyDown(KeyCode.Space))
        {
            UIManager.Instance.ShowLeaderboard();
            UIManager.Instance.ShowLeaderboardGuideDesc(false);
        }
    }

    // show button when player is in npc's collider area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInside = true;
        interactButton.SetActive(isInside);
        // call desc
        UIManager.Instance.ShowLeaderboardGuideDesc(isInside);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
        interactButton.SetActive(isInside);
        // de-call desc
        UIManager.Instance.ShowLeaderboardGuideDesc(isInside);
    }
}
