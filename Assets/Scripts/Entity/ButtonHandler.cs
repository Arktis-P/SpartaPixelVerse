using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    // for interact buttons
    public GameObject interactButton;
    private bool isInside = false;  // check if player is in its collider area
    
    void Start()
    {
        // initialize interact button
        if (interactButton == null) return;
        interactButton.SetActive(false);
    }

    void Update()
    {
        if (isInside && Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(1);
    }

    // show button when player is in npc's collider area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInside = true;
        interactButton.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
        interactButton.SetActive(false);
    }
}
