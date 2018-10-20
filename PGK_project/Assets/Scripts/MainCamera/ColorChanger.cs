using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

    public Color color1 = Color.blue;
    public Color color2 = Color.red;
    public Color color3 = Color.green;
    public float duration = 1.0f;
    private int colorFlag = 0;
    public Camera cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }
	
	// Update is called once per frame
	void Update () {

        float r = Mathf.Sin(duration*Time.time);
        float g = Mathf.Sin(duration*Time.time*3.14f);
        float b = Mathf.Cos(duration * Time.time+3);

        cam.backgroundColor = new Vector4(r, g , b , 0.5f );
        
    }
}
