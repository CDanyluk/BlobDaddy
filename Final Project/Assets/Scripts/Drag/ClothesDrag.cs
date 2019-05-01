using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesDrag : MonoBehaviour
{

    private GameObject item; //itemBeingDragged
    private GameObject person; //the character to dress

    private BoxCollider item_collider;
    private BoxCollider2D person_collider;

    static Vector3 startPosition;
    static Transform startParent;

    //Sprite Renderer
    private SpriteRenderer Sprite;

    //Variables
    private bool isPressed = false;
    void Start()
    {
        item = gameObject;
        person = GameObject.FindWithTag("person");

        item_collider = item.GetComponent<BoxCollider>();
        person_collider = person.GetComponent<BoxCollider2D>();
        startParent = transform.parent;

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
            // Snap
            startPosition = transform.position;

            Vector2 MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(MousePosition);
            transform.position = objPosition;

            Collider2D[] overlap = Physics2D.OverlapAreaAll(person_collider.bounds.min, person_collider.bounds.max);

            if (overlap.Length > 1)
            {
                if (GameManager.money >= 10000)
                {
                    GameManager.removeMoney(10000);
                    transform.SetParent(person.transform);
                }
            }

        }
    }
}

