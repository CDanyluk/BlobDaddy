using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDrag : MonoBehaviour
{

    //Sprite Renderer
    private SpriteRenderer Sprite;

    //Variables
    private bool isPressed = false;
    void Start()
    {
        //Intialisation
        Sprite = gameObject.GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        Pressed();
    }

    void OnMouseDown()
    {
        isPressed = true;
    }
    void OnMouseUp()
    {
        isPressed = false;
    }
    void Pressed()
    {
        if (isPressed)
        {
            Vector2 MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(MousePosition);
            transform.position = objPosition;
        }
    }
}

