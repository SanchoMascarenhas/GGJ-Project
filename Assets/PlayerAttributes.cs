using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour {

    public float maxHealth;
    public float maxBreath;
    public float currentHealth;
    public float currentBreath;
    public Slider breathSlider;

	// Use this for initialization
	void Start () {
        currentBreath = maxBreath;
        currentHealth = maxHealth;
        breathSlider.value = maxBreath;
	}
	
	// Update is called once per frame
	void Update () {
        currentBreath += 0.005f;
        if (currentBreath > 5)
        {
            currentBreath = 5;
        }
        else if(currentBreath < 0)
        {
            currentBreath = 0;
        }
        breathSlider.value = currentBreath;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
    }

    public void ConsumeBreath(float amount)
    {
        currentBreath -= amount;
        breathSlider.value = currentBreath;
    }
}
