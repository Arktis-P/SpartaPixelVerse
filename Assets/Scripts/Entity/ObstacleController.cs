using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float lowPosY = -2f;
    public float highPosY = 2f;

    public float holeSizeMin = 2f;
    public float holesizeMax = 6f;

    public Transform topObject;
    public Transform botObject;

    public float padWidth = 8f;

    public Vector3 SetRandomPlace(Vector3 lastPos, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holesizeMax);
        float halfHoleSize = holeSize / 2f;

        // widen the gap between top and bot
        topObject.localPosition = new Vector3(0, halfHoleSize);
        botObject.localPosition = new Vector3(0, -halfHoleSize);

        // place new obstacles
        Vector3 placePos = lastPos + new Vector3(padWidth, 0, 0);
        placePos.y = Random.Range(lowPosY, highPosY);
        transform.position = placePos;

        return placePos;
    }
}
