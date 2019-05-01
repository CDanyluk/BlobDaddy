using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CoinClick : MonoBehaviour
{
    
    void OnMouseDown()
    {
        if (this.gameObject.tag == "gold") {
            GameManager.addMoney(100);
        } else if (this.gameObject.tag == "silver")
        {
            GameManager.addMoney(25);
        }
        else if (this.gameObject.tag == "bronze") {
        GameManager.addMoney(10);
        }
        Destroy(this.gameObject);
    }

}
