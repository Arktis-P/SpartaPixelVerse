using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NPCController : BaseController
{
    private float timer = 0f;
    private float timeInterval = 2f;

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
}
