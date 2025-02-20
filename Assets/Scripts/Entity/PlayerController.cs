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
    private SpriteRenderer petRenderer;

    protected override void Start()
    {
        camera = Camera.main;

        isPet = GameManager.Instance.IsPet;
        petRenderer = pet.GetComponentInChildren<SpriteRenderer>();

        EquipPet();  // check if player has pet
    }

    private void Update()
    {
        Rotate(lookDirection);
        PetRotate(lookDirection);
    }

    // equip pet method
    public void EquipPet()
    {
        isPet = GameManager.Instance.IsPet;
        if (isPet)
        {
            pet.SetActive(isPet);
            moveSpeed = moveSpeed * 1.5f;
        }
        else
        {
            pet.SetActive(isPet);
            moveSpeed = 5f;
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

    void PetRotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        petRenderer.flipX = isLeft;
    }
}
