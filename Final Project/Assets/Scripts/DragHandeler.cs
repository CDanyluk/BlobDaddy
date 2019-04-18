using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Tutorial Used: https://www.youtube.com/watch?v=c47QYgsJrWc
// Solution to object disapearing: https://www.youtube.com/watch?v=opZhSxR9mUA

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject item; //itemBeingDragged
    public GameObject person; //the character to dress

    static Vector3 startPosition;
    static Transform startParent;

    void Start()
    {
        startPosition = transform.position;
        startParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        item = gameObject;
        person = GameObject.FindWithTag("person");
        //startPosition = transform.position;
        //startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        BoxCollider item_collider = item.GetComponent<BoxCollider>();
        BoxCollider person_collider = person.GetComponent<BoxCollider>();

        if (item_collider.bounds.Intersects(person_collider.bounds)) {
            Debug.Log("overlap");
            //item = null;
            //transform.SetParent(startParent.parent);

        }
        else
        {
            item = null;
            transform.position = startPosition;
            //transform.SetParent(startParent);
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
