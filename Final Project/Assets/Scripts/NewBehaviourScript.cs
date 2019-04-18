using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour
{
    public Text text;
    public Button button;
    private List<int> goodclothes;
    public GameObject slots;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
        System.Random random = new System.Random();
        goodclothes = new List<int>()
        {random.Next(8),random.Next(8),random.Next(8)};
    }

    void TaskOnClick()
    {
        int correct = 0;
        for (int i = 0; i < 8; i++){
            if (slots.transform.GetChild(i).transform.childCount == 0 
                && goodclothes.Contains(i)){
                     correct++;
            }
        }
        text.text = "Karaman is wearing "  + correct + " peices of clothes";

    }
}
