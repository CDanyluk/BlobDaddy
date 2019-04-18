using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float timeLeft;
    public Rigidbody2D rb;
    public float speed = 1;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += accelerationTime;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
        //transform.Translate(direction * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var tag = col.gameObject.tag;
        if (tag == "EdgeX")
        {
            movement.x *= -1;
        } else
        {
            movement.y += -1;
        }
    }

}