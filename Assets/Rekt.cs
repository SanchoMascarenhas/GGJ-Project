using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rekt : MonoBehaviour {

    public GameObject rektPrefab;


    public void youGotRekt()
    {
        GameObject rekt = (GameObject)Instantiate(rektPrefab, transform.position, Quaternion.Euler(0, 0, 90));
    }
}
