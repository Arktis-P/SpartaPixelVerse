using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorHandler : MonoBehaviour
{
    public GameObject player;
    private SpriteRenderer renderer;

    private void Start()
    {
        renderer = player.GetComponentInChildren<SpriteRenderer>();
    }

    private void ChangeColor(Color newColor)
    {
        if (renderer == null) { Debug.LogError("Sprite Renderer NOT found!"); return; }
        // change color
        renderer.color = newColor;
    }

    public void ChangeWhite()
    {
        ChangeColor(Color.white);
    }
    public void ChangeBlack()
    {
        ChangeColor(Color.black);
    }
    public void ChangeRed()
    {
        ChangeColor(Color.red);
    }
    public void ChangeBlue()
    {
        ChangeColor(Color.blue);
    }
    public void ChangeGreen()
    {
        ChangeColor(Color.green);
    }
}
