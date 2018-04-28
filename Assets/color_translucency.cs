using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_translucency : MonoBehaviour {
    private Color originalColor;

    // Use this for initialization
    void Start()
    {
        var newColor = new Color(Random.Range((float)0.0, (float)1.0), Random.Range((float)0.0, (float)1.0), Random.Range((float)0.0, (float)1.0));
        this.GetComponent<Renderer>().material.color = newColor;
        //originalColor = this.GetComponent<Renderer>().material.color;

        originalColor = newColor;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnSelect()
    {
        var cube = this.GetComponent<Renderer>();
        cube.material.color = Color.magenta;
    }

    void OnReset()
    {
        var cube = this.GetComponent<Renderer>();
        cube.material.color = originalColor;
    }
}
