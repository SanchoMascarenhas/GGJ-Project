using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveSpawner : MonoBehaviour {

    public GameObject shockwavePrefab;

    Vector3[] spawningPositions;

    int TOTAL_PROBABILITY = 10;
    int LOW_PROBABILITY = 2;
    int MEDIUM_PROBABILITY = 3;
    const int FAR_DISTANCE = 15;
    const int MEDIUM_DISTANCE = 10;
    const int CLOSE_DISTANCE = 5;

	// Use this for initialization
	void Start () {
        spawningPositions = new Vector3[8];
        spawningPositions[0] = new Vector3(-1f, 0f);
        spawningPositions[1] = new Vector3(1f, 0f);
        spawningPositions[2] = new Vector3(0f, -1f);
        spawningPositions[3] = new Vector3(0f, 1f);
        spawningPositions[4] = new Vector3(-0.5f, -2.23f);
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
        int spawnLocation = Random.Range(0, TOTAL_PROBABILITY);
        Vector2 randomDirection = Random.insideUnitCircle;
        randomDirection.Normalize();
        Vector3 pos = GameObject.Find("Player").GetComponent<PlayerMovement>().transform.position;
        int distance;
        if (spawnLocation < LOW_PROBABILITY) {
            distance = FAR_DISTANCE;
        }
        else if(spawnLocation < MEDIUM_PROBABILITY)
        {
            distance = CLOSE_DISTANCE;
        }
        else
        {
            distance = MEDIUM_DISTANCE;
        }

        Debug.Log("distance = " + distance);
        randomDirection.x *= distance;
        randomDirection.y *= distance;
        pos.x += randomDirection.x;
        pos.y += randomDirection.y;

        GameObject spawn = (GameObject)Instantiate(shockwavePrefab, pos, Quaternion.identity);
        //}
    }
}
