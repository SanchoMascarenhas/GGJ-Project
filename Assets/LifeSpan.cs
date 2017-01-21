using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour {

    // Use this for initialization
    public float timeToLive;
    void Start () {
        //timeToLive = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        timeToLive -= Time.deltaTime;
        if (timeToLive < 0)
        {
            Destroy(this.gameObject);
        }
	}
}
