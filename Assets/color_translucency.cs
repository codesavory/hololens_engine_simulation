using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_translucency : MonoBehaviour {
    private Color originalColor;

    // Use this for initialization
    void Start()
    {
        /*var newColor = new Color(Random.Range((float)0.0, (float)1.0), Random.Range((float)0.0, (float)1.0), Random.Range((float)0.0, (float)1.0));
        this.GetComponent<Renderer>().material.color = newColor;
        originalColor = newColor;*/

        var cube = this.GetComponent<Renderer>();
        originalColor = cube.material.color;
        cube.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.05f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnSelect()
    {
        var cube = this.GetComponent<Renderer>();
        cube.material.color = new Color(0.5f, 0.0f, 0.0f, 1.0f);
    }

    void OnReset()
    {
        var cube = this.GetComponent<Renderer>();
        cube.material.color = new Color(originalColor.r,originalColor.g,originalColor.b,0.05f);
    }
}
