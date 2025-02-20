using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera;
    private bool isPet;
    public GameObject pet;

    protected override void Start()
    {
        camera = Camera.main;

        isPet = GameManager.Instance.IsPet;
    }

    // equip pet method
    public void EquipPet()
    {
        GameManager.Instance.SetPet();
        isPet = GameManager.Instance.IsPet;
        if (isPet)
        {
            pet.SetActive(isPet);
            moveSpeed = moveSpeed * 1.5f;
        }
    }

    // events with on input
    void OnMove(InputValue inputValue)
    {
        moveDirection = inputValue.Get<Vector2>();
        moveDirection = moveDirection.normalized;
    }
    void OnLook(InputValue inputValue)
    {
        Vector2 mousePos = inputValue.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePos);
        lookDirection = worldPos - (Vector2)transform.position;

        if (lookDirection.magnitude < .9f) lookDirection = Vector2.zero;
        else lookDirection = lookDirection.normalized;
    }
}
