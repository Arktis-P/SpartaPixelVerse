using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopController : MonoBehaviour
{
    public int mapObjCount = 7;

    void Start()
    {
        // find all obstacle objects
        // set all obstacles at random position (first in time)
    }

    // loop
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // loop map objects (floors, upper walls, down walls)
        if (collision.CompareTag("Map"))
        {
            float mapObjectWidth = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += mapObjectWidth * mapObjCount;
            collision.transform.position = pos;
            return;
        }
        
        // loop obstacle objects
    }
}
