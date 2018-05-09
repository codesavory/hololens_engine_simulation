using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class color_translucency : MonoBehaviour {
    private Color originalColor;
    public Text myText;
    public float fadeTime;
    public string componentName;
    public string myString;
    // Use this for initialization
    void Start()
    {
        /*var newColor = new Color(Random.Range((float)0.0, (float)1.0), Random.Range((float)0.0, (float)1.0), Random.Range((float)0.0, (float)1.0));
        this.GetComponent<Renderer>().material.color = newColor;
        originalColor = newColor;*/

        var cube = this.GetComponent<Renderer>();
        originalColor = cube.material.color;
        cube.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.05f);

        componentName = this.GetComponent<Renderer>().name;
        System.Diagnostics.Debug.WriteLine("componentName:" + componentName);
        myText = GameObject.Find("Text").GetComponent<Text>();
        myText.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnSelect()
    {
        var cube = this.GetComponent<Renderer>();
        cube.material.color = new Color(0.5f, 0.0f, 0.0f, 1.0f);

        myText.text = myString;
        myText.color = Color.Lerp(myText.color, Color.white, fadeTime*Time.deltaTime);
    }

    void OnReset()
    {
        var cube = this.GetComponent<Renderer>();
        cube.material.color = new Color(originalColor.r,originalColor.g,originalColor.b,0.05f);

        myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
    }
}
