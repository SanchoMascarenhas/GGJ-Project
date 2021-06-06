using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public AudioSource rocks;
    public AudioSource screams;
    public AudioSource hitTaken;
    public AudioSource music;
    public AudioClip start;
    public AudioClip gameOver;
    public AudioClip music180BPM;
    public AudioClip music220BPM;
    public AudioClip music250BPM;
    public AudioClip music300BPM;
    public AudioClip hitTaken1;
    public AudioClip hitTaken2;
    public AudioClip hitTaken3;
    public AudioClip scream;
    public AudioClip powerScream;
    public AudioClip rockHittingGround;

    public static MusicPlayer thisInstance;

    // Use this for initialization
    void Awake () {
        Time.timeScale = 1;
        thisInstance = this;
        thisInstance.hitTaken.loop = false;
        thisInstance.screams.loop = false;
        thisInstance.rocks.loop = false;
        thisInstance.music.loop = false;
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void PlayMusic (string name)
    {
        if(name == "180") {
            music.clip = music180BPM;
        }
        else if (name == "220") {
            music.clip = music220BPM;
        }
        else if (name == "250")
        {
            music.clip = music250BPM;
        }
        else if (name == "300")
        {
            music.clip = music300BPM;
        }
        else if (name == "start")
        {
            music.clip = start;
        }
        else if (name == "end")
        {
            music.clip = gameOver;
        }
        music.Play();
    }

    public void PlaySound (string sound)
    {
        if (sound == "damage")
        {
            int rand = Random.Range(1, 3);
            switch (rand)
            {
                case 1: hitTaken.clip = hitTaken1;
                    break;
                case 2: hitTaken.clip = hitTaken2;
                    break;
                default:
                    hitTaken.clip = hitTaken3;
                    break;
            }
            hitTaken.Play();
        }
        else if (sound == "scream")
        {
            screams.clip = scream;
            screams.Play();
        }
        else if (sound == "powerScream")
        {
            screams.clip = powerScream;
            screams.Play();
        }
        else if (sound == "rock")
        {
            rocks.clip = rockHittingGround;
            rocks.Play();
        }
    }
}
