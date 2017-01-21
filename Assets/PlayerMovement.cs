using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject ScreamPrefab;
    public GameObject PowerScreamPrefab;
    public GameObject ForcePrefab;
    public GameObject BreathPrefab;
    GameObject ForceBar;
    public Quaternion rot;
    public float waveVelocity;
    public float force;
    public float breath;
    bool charging = false;

    PlayerAttributes attributes;

    void Start()
    {
        waveVelocity = 5.0f;
        force = 0.0f;
        charging = false;
        attributes = GetComponent<PlayerAttributes>();
    }

	void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        GetComponent<Rigidbody2D>().angularVelocity = 0;

        if (Input.GetButton("Fire1") && attributes.currentBreath >= 2)
        {
            if (!charging)
            {
                ForceBar = (GameObject)Instantiate(ForcePrefab);
                ForceBar.transform.GetComponent<Renderer>().material.color = new Color(1, 1, 0);
                charging = true;
            }
            
            if (force <= 1.0f)
            {
                force += Time.deltaTime;
                ForceBar.transform.GetComponent<Renderer>().transform.localScale = new Vector3(force, 0.3f, 0);
                ForceBar.transform.GetComponent<Renderer>().material.color = new Color(1, 1 - force, 0);
            }
        }
        

        if (Input.GetButtonUp("Fire1"))
        {
            if (force > 1.0f)
            {
                GameObject PowerScreamWave = (GameObject)Instantiate(PowerScreamPrefab, transform.position, rot * Quaternion.Euler(0, 0, 90));
                Vector2 shootDir = (mousePosition - transform.position).normalized;
                PowerScreamWave.GetComponent<Rigidbody2D>().velocity = waveVelocity * shootDir;
                attributes.ConsumeBreath(2);
                force = 0.0f;
            }
            else
            {
                GameObject screamWave = (GameObject)Instantiate(ScreamPrefab, transform.position, rot * Quaternion.Euler(0, 0, 90));
                Vector2 shootDir = (mousePosition - transform.position).normalized;
                screamWave.GetComponent<Rigidbody2D>().velocity = waveVelocity * shootDir;
                attributes.ConsumeBreath(1);
                force = 0.0f;
            }
            Destroy(ForceBar);
            charging = false;
        }
        
    }

    void Scream()
    {

    }
}
