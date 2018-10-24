using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {
    public DrugsTimer hero;
    public float duration = 1.0f;
    public Camera cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }
	
	// Update is called once per frame
	void Update () {
        if(hero.tookDrug == true)
        {
        float r = Mathf.Sin(duration*Time.time);
        float g = Mathf.Sin(duration*Time.time*3.14f);
        float b = Mathf.Cos(duration * Time.time+3);
        cam.backgroundColor = new Vector4(r, g , b , 0.5f );
        }  
    }
}
