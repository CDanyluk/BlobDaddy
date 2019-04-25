using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    bool gameOver = false;
    string overString = "";
    private GUIStyle guiStyle = new GUIStyle();
    //public Image endScreen;
    public TextMeshProUGUI moneyText;
    public static int money;
    public static string blobType;

    //public static float exp;
    public static float blueExp;
    public static float redExp;
    public static float yellowExp;
    public GameObject blobChild;
    public static List<GameObject> Children;

    void Start()
    {
        // Set things up
        money = 10000;
        blobType = "blob";

        // Evolution code
        Children = new List<GameObject>();
        foreach (Transform child in blobChild.transform)
        {
            Children.Add(child.gameObject);
        }
        Debug.Log(Children.Count);

    }

    private static void resetBlob()
    {
        blobType = "blob";
        Children[0].SetActive(true);
        Children[1].SetActive(false);
        Children[2].SetActive(false);
        Children[3].SetActive(false);
        Children[4].SetActive(false);
    }

    private static void evolveYellow()
    {
        blobType = "yellow";
        Children[0].SetActive(false);
        Children[1].SetActive(true);
        Children[2].SetActive(false);
        Children[3].SetActive(false);
        Children[4].SetActive(false);
    }

    private static void evolveBlue()
    {
        blobType = "blue";
        Children[0].SetActive(false);
        Children[1].SetActive(false);
        Children[2].SetActive(false);
        Children[3].SetActive(true);
        Children[4].SetActive(false);
    }

    private static void evolveRed()
    {
        blobType = "red";
        Children[0].SetActive(false);
        Children[1].SetActive(false);
        Children[2].SetActive(true);
        Children[3].SetActive(false);
        Children[4].SetActive(false);
    }


    void Update()
    {
        moneyText.text = "Money: " + money;

    }

    public static void addMoney(int num)
    {
        money += num;
    }

    public static void removeMoney(int num)
    {
        money -= num;
    }



    public static void checkEvolve()
    {
        Debug.Log(GameManager.blueExp);
        Debug.Log(GameManager.redExp);
        Debug.Log(GameManager.yellowExp);
        if (blueExp + yellowExp + redExp >= 1)
        {
            if (blueExp >= yellowExp && blueExp >= redExp)
                evolveBlue();
            else if (yellowExp >= redExp && yellowExp >= blueExp)
                evolveYellow();
            else
                evolveRed();
            blueExp = 0;
            redExp = 0;
            yellowExp = 0;
        }
    }

    public static void addBlueExp(float num)
    {
        blueExp += num;
        checkEvolve();
    }

    public static void addRedExp(float num)
    {
        redExp += num;
        checkEvolve();
    }

    public static void addYellowExp(float num)
    {
        yellowExp += num;
        checkEvolve();
    }

    public void EndGame()
    {
        if (gameOver == false)
        {
            gameOver = true;
            //endScreen.enabled = true;

        }
        else if (gameOver == true)
        {
            if (Input.GetKeyDown("s"))
            {
                Restart();
            }

        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Handles the text in the corner
    void OnGUI()
    {
        guiStyle.fontSize = 70;
        int TextWidth = 200;
        GUI.Label(new Rect(Screen.width - TextWidth, 200, TextWidth, 20), overString, guiStyle);
    }

}
