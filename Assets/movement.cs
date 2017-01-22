using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    float speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        

        /** /
        if(Input.GetKeyDown(KeyCode.W)) {
            Vector3 pos = transform.position;
            pos.y += 1;
            transform.position = pos;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 pos = transform.position;
            pos.y -= 1;
            transform.position = pos;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 pos = transform.position;
            pos.x -= 1;
            transform.position = pos;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 pos = transform.position;
            pos.x += 1;
            transform.position = pos;
        }
    /**/
    }
}
