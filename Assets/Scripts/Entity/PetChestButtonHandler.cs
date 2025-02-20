using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetChestButtonHandler : MonoBehaviour
{
    public GameObject interactButton;
    private bool isInside = false;

    public GameObject player;
    private PlayerController playerController;

    void Start()
    {
        if (interactButton == null) return;
        interactButton.SetActive(isInside);

        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (isInside && Input.GetKeyDown(KeyCode.Space))
        {
            // euqip pet
            playerController.EquipPet();
            UIManager.Instance.ShowPetChestDesc(false);
        }
    }

    // show button
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInside = true;
        interactButton.SetActive(isInside);
        // call desc
        UIManager.Instance.ShowPetChestDesc(isInside);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
        interactButton.SetActive(isInside);
        // de-call desc
        UIManager.Instance.ShowPetChestDesc(isInside);
    }
}
