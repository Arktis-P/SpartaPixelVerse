using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopController : MonoBehaviour
{
    public int mapObjCount = 7;

    public int obstacleCount = 0;
    public Vector3 obstacleLastPos = Vector3.zero;

    void Start()
    {
        // find all obstacle objects
        ObstacleController[] obstacles = GameObject.FindObjectsOfType<ObstacleController>();
        obstacleLastPos = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        // set all obstacles at random position (first in time)
        for (int i = 0; i < obstacleCount; i++)
            obstacleLastPos = obstacles[i].SetRandomPlace(obstacleLastPos, obstacleCount);
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
        ObstacleController obstacle = collision.GetComponent<ObstacleController>();
        if (obstacle)
            obstacleLastPos = obstacle.SetRandomPlace(obstacleLastPos, obstacleCount);
    }
}
