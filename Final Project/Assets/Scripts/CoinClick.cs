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
        GameManager.addMoney(10);
        Destroy(this.gameObject);
    }

}
