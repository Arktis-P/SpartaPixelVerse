using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NPCController : BaseController
{
    private float timer = 0f;
    private float timeInterval = 2f;
    // for interact buttons
    public GameObject interactButton;
    private bool isInside = false;  // check if player is in its collider area

    protected override void Start()
    {
        // initialize interact button
        if (interactButton == null) return;
        interactButton.SetActive(false);
    }

    // set random lookDirection every 2 sec for npc flip
    protected override void Update()
    {
        // set timer to check interval
        timer += Time.deltaTime;
        
        if (timer >= timeInterval)
        {
            lookDirection = SetRandomDirection();  // set random Vector2 value to lookDirection
            timer -= timeInterval;  // initialize timer
        }

        Rotate(lookDirection);
    }

    private Vector2 SetRandomDirection()
    {
        Vector2 direction = new Vector2(
            Random.Range(-5f,5f), Random.Range(-3f,3f)
            );
        return direction = direction.normalized;
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
