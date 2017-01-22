using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    GameObject ForceBar;
    public Quaternion rot;
    float speed = 4.0f;
    Vector3 movement;
    Rigidbody2D playerRigidbody;

    PlayerAttributes attributes;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        attributes = GetComponent<PlayerAttributes>();
    }

    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Move the player around the scene.
        Move(h, v);
    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, v, 0f);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Shockwave" /*|| collision.tag == "Rock"*/)
        {
            this.GetComponent<PlayerAttributes>().TakeDamage(1);
            Destroy(collision.gameObject);
        }
        else if(collision.tag == "Wall")
        {

        }

    }
}
