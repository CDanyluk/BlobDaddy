using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Tutorial Used: https://www.youtube.com/watch?v=c47QYgsJrWc
// Solution to object disapearing: https://www.youtube.com/watch?v=opZhSxR9mUA

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject item; //itemBeingDragged
    private GameObject person; //the character to dress

    private BoxCollider item_collider;
    private BoxCollider person_collider;

    Vector3 localScale;

    private Camera cam;

    static Vector3 startPosition;
    static Transform startParent;

    void Start()
    {
        item = GameObject.FindWithTag("crown");
        person = GameObject.FindWithTag("person");

        item_collider = item.GetComponent<BoxCollider>();
        person_collider = person.GetComponent<BoxCollider>();

        cam = Camera.main;
        startPosition = new Vector3(75f, -62.5f, 0f);
        Debug.Log(startPosition);
        startParent = transform.parent;

        localScale = item.transform.localScale;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //item = gameObject;
        //person = GameObject.FindWithTag("person");
        startPosition = transform.position;
        //startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var position = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = position;
        transform.position = new Vector3(transform.position.x, transform.position.y, 100);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        //BoxCollider item_collider = item.GetComponent<BoxCollider>();
        //BoxCollider person_collider = person.GetComponent<BoxCollider>();

        if (item_collider.bounds.Intersects(person_collider.bounds)) {
            Debug.Log("overlap");
            //item.transform.SetParent(person.transform.parent);
            //var position = cam.ScreenToWorldPoint(Input.mousePosition);
            //transform.position = position;
            //transform.position = new Vector3(transform.position.x, transform.position.y, 100);
            item = null;

        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
