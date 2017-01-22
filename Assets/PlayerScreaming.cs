using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScreaming : MonoBehaviour
{

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
    const float MINIMUM_BREATH_FORCE = 1.5f;
    const float MINIMUM_BREATH = 1f;
    float timer =  0.0f;
    const float MINIMUM_BREATH_FORCE_TIME = 1.5f;
    SpriteRenderer renderer;

    public Sprite idle;
    public Sprite charge;
    public Sprite unleashNormal;
    public Sprite unleashPowerful;
    Color originalColor;
    float screamTimer = 0.0f;
    float SCREAM_TIMER_SPRITE_CHANGE = 1.0f;

    PlayerAttributes attributes;
    private float duration = 1.5f;

    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        originalColor = renderer.color;
        powerWaveVelocity = 2.0f;
        waveVelocity = 7.5f;
        force = 0.0f;
        charging = false;
        attributes = GetComponent<PlayerAttributes>();
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        GetComponent<Rigidbody2D>().angularVelocity = 0;

        if (Input.GetMouseButtonUp(0) && attributes.currentBreath >= MINIMUM_BREATH)
        {
            if (timer >= MINIMUM_BREATH_FORCE_TIME)
            {
                renderer.sprite = unleashPowerful;
                GameObject PowerScreamWave = (GameObject)Instantiate(PowerScreamPrefab, transform.position, rot * Quaternion.Euler(0, 0, 90));
                Vector2 shootDir = (mousePosition - transform.position);
                PowerScreamWave.GetComponent<Rigidbody2D>().velocity = (waveVelocity * shootDir.normalized);
                attributes.ConsumeBreath(2);
            }
            else {
                renderer.sprite = unleashNormal;
                GameObject screamWave = (GameObject)Instantiate(ScreamPrefab, transform.position, rot * Quaternion.Euler(0, 0, 90));
                Vector2 shootDir = (mousePosition - transform.position);
                screamWave.GetComponent<Rigidbody2D>().velocity = (waveVelocity * shootDir.normalized);
                attributes.ConsumeBreath(1);
            }
            timer = 0.0f;
            renderer.color = originalColor;
            renderer.sprite = idle;
        }
        if (Input.GetMouseButton(0) && attributes.currentBreath >= MINIMUM_BREATH_FORCE)
        {
            renderer.sprite = charge;
            timer += Time.deltaTime;
            ChangeColor();
        }
    }

    void ChangeColor()
    {
        renderer.color = Color.Lerp(originalColor, new Color(0,0,102), timer/duration);
    }
}
