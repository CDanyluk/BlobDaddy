using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnScript : MonoBehaviour
{

    private GameObject gold;
    private GameObject silver;
    private GameObject bronze;
    private GameObject coin;
    private int coinNum;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        gold = GameObject.FindWithTag("gold");
        silver = GameObject.FindWithTag("silver");
        bronze = GameObject.FindWithTag("bronze");
        coin = bronze;
        coinNum = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        { 
            nextSpawn = Time.time + spawnRate;
            whereToSpawn = new Vector3(transform.position.x, transform.position.y + 1.3f, 12);
            Instantiate(coin, whereToSpawn, Quaternion.identity);

        }
        if (GameManager.blobType == "blue" || GameManager.blobType == "blue2")
        {
            coin = gold;
            spawnRate = 3f;
        }else if (GameManager.blobType == "yellow" || GameManager.blobType == "yellow2")
        {
            coin = silver;
            spawnRate = 1.5f;
        }else if (GameManager.blobType == "red" || GameManager.blobType == "red2")
        {
            coin = bronze;
            spawnRate = 0.8f;
        } else if (GameManager.blobType == "orange")
        {
            coin = silver;
            spawnRate = 0.8f;
        }
        else if (GameManager.blobType == "purple")
        {
            coin = gold;
            spawnRate = 0.8f;
        }
        else if (GameManager.blobType == "green")
        {
            coin = gold;
            spawnRate = 1.5f;
        }


    }
}
