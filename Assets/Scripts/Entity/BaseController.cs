using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Transform weaponPivot;
    // movement directions => arrow keys or wasd
    protected Vector2 moveDirection = Vector2.zero;
    public Vector2 MoveDirection { get { return moveDirection; } }
    // looking direction => change according to mouse position (for player)
    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }
    // handlers for entities
    protected AnimationHandler animationHandler;
    protected StatHandler statHandler;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        Rotate(lookDirection);
    }

    protected virtual void FixedUpdate()  // update for fixed frame rate
    {
        Move(moveDirection);
    }

    private void Move(Vector2 direction)  // move at certain speed in the direction
    {
        direction = direction * 5f;

        _rigidbody.velocity = direction;
        animationHandler.Move(direction);
    }
    protected void Rotate(Vector2 direction)  // rotat entity at the direction of its looking
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;  // convert status of flipX if isLeft is true
    }
}
