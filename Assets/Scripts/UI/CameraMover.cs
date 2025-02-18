using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform target;
    float offsetX;

    private void Start()
    {
        if (target == null) return;  // process exception
    }

    private void Update()
    {
        if (target == null) return;  // process exception
        // move camera as player obj moves
        Vector3 pos = transform.position;
        pos.x = target.position.x; pos.y = target.position.y;
        transform.position = pos;
    }
}
