using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockFall : MonoBehaviour
{

    float distanceFallen;
    public int health = 3;

    // Use this for initialization
    void Start()
    {
        distanceFallen = 0f;
        InvokeRepeating("TimedUpdate", 0, 0.016667f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TimedUpdate()
    {
        Vector3 currentPosition = transform.localPosition;
        distanceFallen += ShockwaveSpawner.FALL_SPEED / 60;
        if(distanceFallen >= ShockwaveSpawner.SPAWN_HEIGHT) {
            this.GetComponent<BoxCollider2D>().enabled = true;
            CancelInvoke("TimedUpdate");
        }
        currentPosition.y -= ShockwaveSpawner.FALL_SPEED / 60;
        transform.localPosition = currentPosition;
        
    }

    public void collision(string tag) {

        if (tag == "Scream")
        {
            health -= 1;
        }
        if (tag == "PowerScream")
        {
            health -= 3;
        }

        if (health <= 0) {
            Destroy(this.gameObject);
        }

    }
}