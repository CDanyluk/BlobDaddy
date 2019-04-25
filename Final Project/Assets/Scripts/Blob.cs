using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{

    private GameObject blobChild;
    public List<GameObject> Children;

    void Start()
    {

        blobChild = gameObject;

        foreach (Transform child in blobChild.transform)
        {
            Children.Add(child.gameObject);
        }
        Debug.Log(Children.Count);

    }

    public void resetBlob()
    {
        Children[0].SetActive(true);
        Children[1].SetActive(false);
    }

    public void evolveYellow()
    {
        Children[0].SetActive(false);
        Children[1].SetActive(true);
    }
 
}
