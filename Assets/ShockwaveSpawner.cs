using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveSpawner : MonoBehaviour {

    public GameObject shockwavePrefab;

    Vector3[] spawningPositions;

	// Use this for initialization
	void Start () {
        spawningPositions = new Vector3[8];
        spawningPositions[0] = new Vector3(-5f, 0f);
        spawningPositions[1] = new Vector3(5f, 0f);
        spawningPositions[2] = new Vector3(0f, -5f);
        spawningPositions[3] = new Vector3(0f, 5f);
        spawningPositions[4] = new Vector3(-2.23f, -2.23f);
        spawningPositions[5] = new Vector3(2.23f, 2.23f);
        spawningPositions[6] = new Vector3(-2.23f, 2.23f);
        spawningPositions[7] = new Vector3(2.23f, -2.23f);
        InvokeRepeating("TimedUpdate", 0, 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TimedUpdate ()
    {
        //if(Random.Range(0, 3) > 0) {
            Vector3 pos = spawningPositions[Random.Range(0, 7)];
            GameObject spawn = (GameObject)Instantiate(shockwavePrefab, pos, Quaternion.identity);
        //}
    }
}
