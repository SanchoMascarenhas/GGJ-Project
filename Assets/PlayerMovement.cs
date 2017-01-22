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
    public float powerWaveVelocity;
    public float force;
    public float breath;
    float speed = 4.0f;
    bool charging = false;

    PlayerAttributes attributes;

    void Start()
    {
        powerWaveVelocity = 4.0f;
        waveVelocity = 7.5f;
        force = 0.0f;
        charging = false;
        attributes = GetComponent<PlayerAttributes>();
    }

	void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        Vector3 barPos;

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        GetComponent<Rigidbody2D>().angularVelocity = 0;

        if (!charging)
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            var result = transform.position + move * speed * Time.deltaTime;

            if (result.x > 21)
            {
                result.x = 21;
            }
            if (result.x < -21)
            {
                result.x = -21;
            }
            if (result.y > 8)
            {
                result.y = 8;
            }
            if (result.y < -8)
            {
                result.y = -8;
            }


            transform.position = result;
        }

        if (Input.GetButton("Fire1") && attributes.currentBreath >= 2)
        {
            if (!charging)
            {
                barPos = new Vector3(transform.position.x, transform.position.y - 0.8f, 0);
                ForceBar = (GameObject)Instantiate(ForcePrefab, barPos, Quaternion.Euler(0,0,0));
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
            if (attributes.currentBreath >= 0.5f)
            {
                if (force > 1.0f)
                {
                    GameObject PowerScreamWave = (GameObject)Instantiate(PowerScreamPrefab, transform.position, rot * Quaternion.Euler(0, 0, 90));
                    Vector2 shootDir = (mousePosition - transform.position.normalized);
                    PowerScreamWave.GetComponent<Rigidbody2D>().velocity = (waveVelocity * shootDir).normalized;
                    attributes.ConsumeBreath(2);
                    force = 0.0f;
                }
                else
                {
                    GameObject screamWave = (GameObject)Instantiate(ScreamPrefab, transform.position, rot * Quaternion.Euler(0, 0, 90));
                    Vector2 shootDir = (mousePosition - transform.position);
                    screamWave.GetComponent<Rigidbody2D>().velocity = (waveVelocity * shootDir.normalized);
                    attributes.ConsumeBreath(1);
                    force = 0.0f;
                }
                Destroy(ForceBar);
                charging = false;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Shockwave" || collision.tag == "Rock")
        {
            this.GetComponent<PlayerAttributes>().TakeDamage(1);
            Destroy(collision.gameObject);
        }
        else if(collision.tag == "Wall")
        {

        }

    }
}
