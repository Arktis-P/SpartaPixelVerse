using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyGuideButtonHandler : MonoBehaviour
{
    public GameObject interactButton;
    private bool isInside = false;  // check if player is in its collider area

    public GameObject flappyGuideDesc;

    private void Start()
    {
        // initialize interact button
        if (interactButton == null) return;
        interactButton.SetActive(false);
    }

    private void Update()
    {
        if (isInside && Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(1);
    }

    // show button when player is in npc's collider area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInside = true;
        interactButton.SetActive(isInside);
        // call desc
        flappyGuideDesc.SetActive(isInside);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
        interactButton.SetActive(isInside);
        // de-call desc
        flappyGuideDesc.SetActive(isInside);
    }
}
