using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Transform target;
    float offsetX;

    private void Start()
    {
        if (target == null) return;  // process exception
        // if on Flappy game screen, get offsetX (distance from camera to player)
        if (SceneManager.GetActiveScene().buildIndex == 1) offsetX = transform.position.x - target.position.x;
        else offsetX = 0f;
    }

    private void Update()
    {
        if (target == null) return;  // process exception
        // move camera as player obj moves
        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        if (SceneManager.GetActiveScene().buildIndex == 0) pos.y = target.position.y;
        transform.position = pos;
    }
}
