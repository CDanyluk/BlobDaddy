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

    // Evolution stuff
    public static float blueExp;
    public static float redExp;
    public static float yellowExp;
    public GameObject blobChild;
    public static List<GameObject> Children;

    // Background
    public GameObject background;
    public static List<GameObject> backgroundImages;

    private Camera cam;

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

        // Background code
        backgroundImages = new List<GameObject>();
        foreach (Transform child in background.transform)
        {
            backgroundImages.Add(child.gameObject);
        }

        cam = Camera.main;

    }

    private static void resetBlob()
    {
        blobType = "blob";
        Children[0].SetActive(true);
        Children[1].SetActive(false);
        Children[2].SetActive(false);
        Children[3].SetActive(false);
        Children[4].SetActive(false);
        Children[5].SetActive(false);
        Children[6].SetActive(false);
        Children[7].SetActive(false);
        Children[8].SetActive(false);
        Children[9].SetActive(false);
    }

    private static void evolveYellow()
    {
        // Set them all to be false
        Children[0].SetActive(false);
        Children[1].SetActive(false);
        Children[2].SetActive(false);
        Children[3].SetActive(false);
        Children[4].SetActive(false);
        Children[5].SetActive(false);
        Children[6].SetActive(false);
        Children[7].SetActive(false);
        Children[8].SetActive(false);
        Children[9].SetActive(false);
        if (blobType == "yellow")
        {
            blobType = "yellow2";
            // Set the second yellow blob to be on and not the first
            Children[2].SetActive(true);
        }
        else if (blobType == "blue2")
        {
            blobType = "green";
            // Set the blob to be green
            Children[7].SetActive(true);
        }
        else if (blobType == "red2")
        {
            blobType = "orange";
            // Set the blob to be orange
            Children[9].SetActive(true);
        }
        else
        {
            // Set the first yellow blob to be on
            blobType = "yellow";
            Children[1].SetActive(true);
        }
    }

    private static void evolveBlue()
    {
        // Set them all to be false
        Children[0].SetActive(false);
        Children[1].SetActive(false);
        Children[2].SetActive(false);
        Children[3].SetActive(false);
        Children[4].SetActive(false);
        Children[5].SetActive(false);
        Children[6].SetActive(false);
        Children[7].SetActive(false);
        Children[8].SetActive(false);
        Children[9].SetActive(false);
        if (blobType == "blue")
        {
            blobType = "blue2";
            // Set the second blue blob to be on and not the first
            Children[6].SetActive(true);
        }
        else if (blobType == "red2")
        {
            blobType = "purple";
            // Set the blob to be purple
            Children[8].SetActive(true);

        }
        else if (blobType == "yellow2")
        {
            blobType = "green";
            // Set the blob to be green
            Children[7].SetActive(true);
        }
        else
        {
            // Set the first blue blob to be on
            blobType = "blue";
            Children[5].SetActive(true);
        }
    }

    private static void evolveRed()
    {
        // Set them all to be false
        Children[0].SetActive(false);
        Children[1].SetActive(false);
        Children[2].SetActive(false);
        Children[3].SetActive(false);
        Children[4].SetActive(false);
        Children[5].SetActive(false);
        Children[6].SetActive(false);
        Children[7].SetActive(false);
        Children[8].SetActive(false);
        Children[9].SetActive(false);
        if (blobType == "red")
        {
            blobType = "red2";
            // Set the second red blob to be on and not the first
            Children[4].SetActive(true);
        } else if (blobType == "blue2")
        {
            blobType = "purple";
            // Set the blob to be purple
            Children[8].SetActive(true);

        } else if (blobType == "yellow2")
        {
            blobType = "orange";
            // Set the blob to be orange
            Children[9].SetActive(true);
        }
        else
        {
            // Set the first red blob to be on
            blobType = "red";
            Children[3].SetActive(true);
        }
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

    public static void setSunset()
    {
        backgroundImages[0].SetActive(false);
        backgroundImages[1].SetActive(true);
        backgroundImages[2].SetActive(false);
    }

    public static void setNight()
    {
        backgroundImages[0].SetActive(false);
        backgroundImages[1].SetActive(false);
        backgroundImages[2].SetActive(true);
    }

    public static void setDay()
    {
        backgroundImages[0].SetActive(true);
        backgroundImages[1].SetActive(false);
        backgroundImages[2].SetActive(false);
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
