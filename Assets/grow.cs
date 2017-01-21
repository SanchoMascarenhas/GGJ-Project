using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grow : MonoBehaviour {

    float size;
    float growthFactor;
    float disappearFactor;
    CircleCollider2D waveCollider;
    SpriteRenderer waveRenderer;
    Color color;

    // Use this for initialization
    void Start () {
        size = 1;
        waveCollider = transform.GetComponent<CircleCollider2D>();
        waveRenderer = transform.GetComponent<SpriteRenderer>();
        color = waveRenderer.material.color;
        growthFactor = 0.1f;
        disappearFactor = 0.007f;
        InvokeRepeating("TimedUpdate", 0, 0.016667f);
    }

    // Update is called once per frame
    void Update () {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collidingObject = collision.collider;

        if(collidingObject.tag == "Player")
        {
            collidingObject.GetComponent<PlayerAttributes>().TakeDamage(1);
            Destroy(this.gameObject);
        }
        if (collidingObject.tag == "Scream")
        {
            Destroy(collidingObject.gameObject);
            Destroy(this.gameObject);
        }
        if (collidingObject.tag == "PowerScream")
        {
            Destroy(this.gameObject);
        }

    }

    void TimedUpdate ()
    {
        size += growthFactor;
        transform.localScale = new Vector3(size, size, 1);
        color.a -= disappearFactor;
        waveRenderer.material.color = color;
        if (color.a <= 25)
        {
            Destroy(this.gameObject);
        }
    }
    
}
