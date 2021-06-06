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
    public Slider healthSlider;
    public Image fill;

    LoadSceneOnClick SceneLoader;

	// Use this for initialization
	void Start () {
        currentBreath = maxBreath;
        currentHealth = maxHealth;
        breathSlider.value = maxBreath;
        healthSlider.value = maxHealth;
        SceneLoader = GetComponent<LoadSceneOnClick>();
    }
	
	// Update is called once per frame
	void Update () {
        if(currentHealth <= 0)
        {
            MusicPlayer.thisInstance.PlayMusic("end");
            gameOver();
        }
        currentBreath += 0.02f;
        if (currentBreath > 5)
        {
            currentBreath = 5;
        }
        else if(currentBreath < 0)
        {
            currentBreath = 0;
        }
        breathSlider.value = currentBreath;
        if(currentBreath < 2.0f)
        {
            fill.color = new Color(1, 0, 0);
        }
        else
        {
            fill.color = new Color(1, 0.8f, 0);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
    }

    public void ConsumeBreath(float amount)
    {
        currentBreath -= amount;
        breathSlider.value = currentBreath;
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        SceneLoader.LoadByIndex(5);
    }
}
