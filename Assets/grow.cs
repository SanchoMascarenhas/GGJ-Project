using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grow : MonoBehaviour {

    float size;
    float growthFactor;
    float disappearFactor;
    CircleCollider2D waveCollider;
    Renderer waveRenderer;
    Color color;

    // Use this for initialization
    void Start () {
        size = 1;
        waveCollider = transform.GetComponent<CircleCollider2D>();
        waveRenderer = transform.GetComponent<Renderer>();
        color = waveRenderer.material.color;
        growthFactor = 0.1f;
        disappearFactor = growthFactor / 10;
    }

    // Update is called once per frame
    void Update () {
        size += growthFactor;
        waveCollider.radius = size;
        transform.localScale = new Vector3(size, size, 1);
        Color color = waveRenderer.material.color;
        color.a -= growthFactor;
        //waveRenderer.material.color = color;
	}
}
