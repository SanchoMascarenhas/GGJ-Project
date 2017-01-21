using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveSpawner : MonoBehaviour {

    public GameObject shockwavePrefab;
    public GameObject shadowPrefab;
    public GameObject rockPrefab;
    Queue<GameObject> shadow = new Queue<GameObject>();

    Queue<Vector3> positionsForSpawn = new Queue<Vector3>();

    int TOTAL_PROBABILITY = 10;
    int LOW_PROBABILITY = 2;
    int MEDIUM_PROBABILITY = 3;
    const float MAX_DISTANCE = 10f;
    const float FAR_DISTANCE = 8f;
    const float MEDIUM_DISTANCE = 6f;
    const float CLOSE_DISTANCE = 3f;

    public const float SPAWN_HEIGHT = 15f;
    public const float FALL_SPEED = 7.5f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("TimedUpdate", 0, 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TimedUpdate() {

        int spawnLocation = Random.Range(0, TOTAL_PROBABILITY);
        Vector2 randomDirection = Random.insideUnitCircle;
        randomDirection.Normalize();
        Vector3 pos = GameObject.Find("Player").GetComponent<PlayerMovement>().transform.position;
        float distance;
        if (spawnLocation < LOW_PROBABILITY) {
            distance = Random.Range(FAR_DISTANCE, MAX_DISTANCE);
        }
        else if(spawnLocation < MEDIUM_PROBABILITY)
        {
            distance = Random.Range(CLOSE_DISTANCE, MEDIUM_DISTANCE);
        }
        else
        {
            distance = Random.Range(MEDIUM_DISTANCE, FAR_DISTANCE);
        }
        
        randomDirection.x *= distance;
        randomDirection.y *= distance;
        float resultX = pos.x + randomDirection.x;
        float resultY = pos.y + randomDirection.y;
        if (resultX > 21 || resultX < -21) {
            resultX = pos.x - randomDirection.x;
        }
        if(resultY > 8 || resultY < -8) {
            resultY = pos.y - randomDirection.y;
        }
        pos.x = resultX;
        pos.y = resultY;


        GameObject rock = (GameObject)Instantiate(rockPrefab, new Vector3(pos.x, pos.y + SPAWN_HEIGHT), Quaternion.identity);
        shadow.Enqueue( (GameObject)Instantiate(shadowPrefab, pos, Quaternion.identity));

        positionsForSpawn.Enqueue(pos);
        Invoke("SpawnWave", SPAWN_HEIGHT/FALL_SPEED);

    }

    void SpawnWave()
    {
        GameObject shockwave = (GameObject)Instantiate(shockwavePrefab, positionsForSpawn.Dequeue(), Quaternion.identity);
        Destroy(shadow.Dequeue());
    }



}
