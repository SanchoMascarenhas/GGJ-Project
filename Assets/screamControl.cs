using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screamControl : MonoBehaviour {

    public int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Scream" || collision.tag == "PowerScream")
        {
            return;
        }
        Debug.Log(health);

        if (health <= 0 && this.tag != "PowerScream")
        {
            Destroy(this.gameObject);
            Debug.Log("Destroying");
        }
        else if (collision.tag == "Rock")
        {
            health--;
            collision.GetComponent<rockFall>().collision(this.tag);
        } else if (collision.tag == "Shockwave")
        {
            health--;
            Destroy(collision.gameObject);
        }
    }
}
