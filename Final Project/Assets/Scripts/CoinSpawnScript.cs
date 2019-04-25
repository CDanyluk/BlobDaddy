using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnScript : MonoBehaviour
{

    private GameObject gold;
    private GameObject silver;
    private GameObject bronze;
    private GameObject coin;
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

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            whereToSpawn = new Vector2(transform.position.x, transform.position.y+1.2f);
            Instantiate(coin, whereToSpawn, Quaternion.identity);
        }
        if (GameManager.blobType == "blue")
        {
            Debug.Log(GameManager.blobType);
            coin = gold;
            Debug.Log(coin.name);
            spawnRate = 2.5f;
        }else if (GameManager.blobType == "yellow")
        {
            Debug.Log(GameManager.blobType);
            coin = silver;
        }else if (GameManager.blobType == "red")
        {
            Debug.Log(GameManager.blobType);
            coin = bronze;
            spawnRate = 1f;
        }
        
    }
}
