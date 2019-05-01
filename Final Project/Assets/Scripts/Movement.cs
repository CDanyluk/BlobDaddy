using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    //Movement
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

        // If the blob runs away, return him
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < -0.1)
        {
            transform.position = new Vector3(0, 0, transform.position.z);
        }
        else if (1.1 < pos.x)
        {
            transform.position = new Vector3(0, 0, transform.position.z);
        }
        else if (pos.y < -0.1)
        {
            transform.position = new Vector3(0, 0, transform.position.z);
        }
        else if (0.6 < pos.y)
        {
            transform.position = new Vector3(0, 0, transform.position.z);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var tag = col.gameObject.tag;
        if (tag == "EdgeX")
        {
            movement.x *= -1;
        }
        else if (tag == "EdgeY")
        {
            {
                movement.y += -1;
            }

            if (col.gameObject.tag == "gold" || col.gameObject.tag == "silver" || col.gameObject.tag == "bronze")
            {
                Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreLayerCollision(5, 8);
            }
        }

    }

}