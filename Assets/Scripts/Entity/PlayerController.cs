using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera;

    protected override void Start()
    {
        camera = Camera.main;
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
