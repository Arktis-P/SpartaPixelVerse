using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorHandler : MonoBehaviour
{
    public GameObject player;
    private SpriteRenderer renderer;

    [SerializeField] public List<Sprite> sprites;

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

    private void ChangeSprite(Sprite newSprite)
    {
        if (renderer == null) { Debug.LogError("Sprite Renderer NOT found!"); return; }
        // change color
        renderer.sprite = newSprite;
    }
    public void ChangeSpriteKnight()
    {
        ChangeSprite(sprites[0]);
    }
    public void ChangeSpriteDwarf()
    {
        ChangeSprite(sprites[1]);
    }
}
