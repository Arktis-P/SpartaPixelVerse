using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 10f;
    public float speed = 5f;

    public bool isStart;
    public bool isDead = false;
    float deathCooldown = 1f;  // time waiting to restart

    bool isFlap = false;

    public bool godMod = false;  // test mode

    FlappyGameManager flappyGameManager;

    void Start()
    {
        flappyGameManager = FlappyGameManager.Instance;

        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animator == null) Debug.LogError("Animator NOT founded!");
        if (_rigidbody == null) Debug.LogError("Rigidbody NOT founded!");

        isStart = flappyGameManager.IsStart;
    }

    // Update is called once per frame
    void Update()
    {
        // get isStart from game manager
        isStart = flappyGameManager.IsStart;
        // Debug.Log($"update isStart {isStart.ToString()}");
        if (!isStart)
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePosition; return;
        }
        else
        {
            _rigidbody.constraints = RigidbodyConstraints2D.None;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            // if isDead is true, show restart UI
            if (isDead)
            {
                if (deathCooldown <= 0) flappyGameManager.GameOver();
                else deathCooldown -= Time.deltaTime;
            }
            else  // if isDead is false, make player flap-possible
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        // make player flap
        if (isDead) return;  // if isDead is true, do not update anything

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = speed;

        if (isFlap)  // if isFlap is true, flap player
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;
    }

    // collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if godMod || isDead, do not process collision
        if (godMod) return;
        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetBool("IsDead", true);
        flappyGameManager.GameOver();
    }
}
