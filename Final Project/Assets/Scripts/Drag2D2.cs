using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag2D2 : MonoBehaviour
{
    //Sprite Renderer
    private SpriteRenderer Sprite;
    public GameObject tie, person;
    Vector2 tieIniPos, personIniPos;

    //Variables
    private bool isPressed = false;
    void Start()
    {
        //Intialisation
        Sprite = gameObject.GetComponent<SpriteRenderer>();
        tieIniPos = tie.transform.position;
        personIniPos = person.transform.position;
    }
    void Update()
    {
        if (isPressed)
        {
            Vector2 MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(MousePosition);
            transform.position = objPosition;
        }
    }

    public void DropTie()
    {
        float distance = Vector2.Distance(tie.transform.position, person.transform.position);
        if (distance < 1)
        {
            tie.transform.position = person.transform.position;
        }
        else
        {
            tie.transform.position = tieIniPos;
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
