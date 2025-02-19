using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Transform target;
    float offsetX;

    float limitX = 4.19f;
    float limitY = 3.25f;

    private void Start()
    {
        if (target == null) return;  // process exception
        // if on Flappy game screen, get offsetX (distance from camera to player)
        if (SceneManager.GetActiveScene().buildIndex == (int)Scenes.MainScene) offsetX = transform.position.x - target.position.x;
        else offsetX = 0f;
    }

    private void Update()
    {
        if (target == null) return;  // process exception
        // hold camera in map area
        Vector3 pos = transform.position;
        // lock camera on main scene
        if (SceneManager.GetActiveScene().buildIndex == (int)Scenes.MainScene)
        {
            // set basic location
            pos.x = target.position.x;
            pos.y = target.position.y;
            // lock location
            if (pos.x >= limitX) pos.x = limitX;
            if (pos.x <= -limitX) pos.x = -limitX;
            if (pos.y >= limitY) pos.y = limitY;
            if (pos.y <= -limitY) pos.y = -limitY;
        }
        else if (SceneManager.GetActiveScene().buildIndex == (int)Scenes.FlappyGameScene)
        {
            pos.x = target.position.x + offsetX;
            pos.y = target.position.y;
        }

        transform.position = pos;
    }
}
