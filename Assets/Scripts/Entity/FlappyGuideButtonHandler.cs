using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyGuideButtonHandler : MonoBehaviour
{
    public GameObject interactButton;
    public static bool isInside = false;  // check if player is in its collider area

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
            UIManager.Instance.ShowFlappyGuideDesc(false);  // turn off the guide text
            UIManager.Instance.ShowFlappyGuideScripts(isInside);
        }
    }

    // show button when player is in npc's collider area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInside = true;
        interactButton.SetActive(isInside);
        // call desc
        UIManager.Instance.ShowFlappyGuideDesc(isInside);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
        interactButton.SetActive(isInside);
        // de-call desc
        UIManager.Instance.ShowFlappyGuideDesc(isInside);
        UIManager.Instance.ShowFlappyGuideScripts(isInside);
    }
}
