using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyGuidButtonHandler : ButtonHandler
{
    protected override void Update()
    {
        if (isInside && Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(1);
    }
}
