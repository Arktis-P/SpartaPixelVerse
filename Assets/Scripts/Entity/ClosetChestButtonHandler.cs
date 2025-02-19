using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetChestButtonHandler : MonoBehaviour
{
    public GameObject interactButton;
    private bool isInside = false;

    void Start()
    {
        if (interactButton == null) return;
        interactButton.SetActive(isInside);
    }

    void Update()
    {
        if (isInside && Input.GetKeyDown(KeyCode.Space))
        {
            // open closet UI
        }
    }

    // show button
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInside = true;
        interactButton.SetActive(isInside);
        // call desc
        UIManager.Instance.ShowClosetChestDesc(isInside);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
        interactButton.SetActive(isInside);
        // de-call desc
        UIManager.Instance.ShowClosetChestDesc(isInside);
    }
}
