using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIElementDragger : MonoBehaviour {

    private bool dragging = false;

    private Vector2 originalPosition;
    private Transform objectToDrag;
    private Image objectToDragImage;

    List<RaycastResult> hitObjects = new List<RaycastResult>();

    #region Monobehavior API

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            objectToDrag = GetDraggableTransformUnderMouse();

            if (objectToDrag != null)
            {
                dragging = true;
                // Set as the last sibling for viewability?
                objectToDrag.SetAsLastSibling();
                //Store original position
                originalPosition = objectToDrag.position;
                objectToDragImage = objectToDrag.GetComponent<Image>();
                objectToDragImage.raycastTarget = false;
            }

        }

        if (dragging)
        {
            objectToDrag.position = Input.mousePosition;
        }

    }

    #endregion

    private GameObject GetObjectUnderMouse()
    {

        var pointer = new PointerEventData(EventSystem.current);

        pointer.position = Input.mousePosition;
        // Raycast to check what is in front or under the cursor
        EventSystem.current.RaycastAll(pointer, hitObjects);

        if (hitObjects.Count <= 0)
        {
            return null;
        }

        return hitObjects[0].gameObject;
    }

    private Transform GetDraggableTransformUnderMouse()
    {
        GameObject clickedObject = GetObjectUnderMouse();

        if (clickedObject != null && clickedObject.tag == "crown")
        {
            return clickedObject.transform;
        }

        return null;

    }

}
