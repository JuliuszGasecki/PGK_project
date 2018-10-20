﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

    public Color color1 = Color.blue;
    public Color color2 = Color.red;
    public Color color3 = Color.green;
    public float duration = 1.0f;

    public Camera cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }
	
	// Update is called once per frame
	void Update () {
        float t = Mathf.Sin(duration*Time.time);
        /* int rand = Random.Range(1, 3);
         if (rand == 1)
             cam.backgroundColor = Color.Lerp(color1, color2, t);
         else if (rand == 2)
             cam.backgroundColor = Color.Lerp(color2, color3, t);
         else if (rand == 3)
             cam.backgroundColor = Color.Lerp(color3, color1, t);
             */
        cam.backgroundColor = Color.Lerp(color1, color3, t);
    }
}
