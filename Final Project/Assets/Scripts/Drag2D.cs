using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag2D : MonoBehaviour
{
    //Sprite Renderer
    private SpriteRenderer Sprite;
    public GameObject item; //itemBeingDragged
    public GameObject person; //the character to dress
    Vector2 itemIniPos, personIniPos;
    Transform startParent;

    //Variables
    private bool isPressed = false;
    void Start()
    {
        //Intialisation
        Sprite = gameObject.GetComponent<SpriteRenderer>();

        // Get item and person from scene
        item = gameObject;
        person = GameObject.FindWithTag("person");

        // Find their initial positions
        itemIniPos = transform.position;
        personIniPos = person.transform.position;

        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        transform.SetParent(transform.root);
    }
    void Update()
    {
        //if (isPressed)
        //{
        //    Vector2 MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //    Vector2 objPosition = Camera.main.ScreenToWorldPoint(MousePosition);
        //    transform.position = objPosition;
        //}
        transform.position = Input.mousePosition;
    }

    public void DropTie()
    {
        float distance = Vector2.Distance(item.transform.position, person.transform.position);
        if (distance < 1)
        {
            item.transform.position = person.transform.position;
        }
        else
        {
            item.transform.position = itemIniPos;
        }
    }

    void OnMouseDown()
    {
        isPressed = true;
    }
    void OnMouseUp()
    {
        isPressed = false;
        DropTie();
    }

}
