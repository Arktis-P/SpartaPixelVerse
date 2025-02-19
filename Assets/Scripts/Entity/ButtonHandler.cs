using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ButtonHandler : MonoBehaviour
{
    // for interact buttons
    public GameObject interactButton;
    protected bool isInside = false;  // check if player is in its collider area

    protected UIManager uiManager;
    
    protected void Start()
    {
        uiManager = UIManager.Instance;

        // initialize interact button
        if (interactButton == null) return;
        interactButton.SetActive(false);
    }

    protected virtual void Update()
    {
        
    }

    // show button when player is in npc's collider area
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }
    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
