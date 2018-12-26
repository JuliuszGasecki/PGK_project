using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkPressSpace : MonoBehaviour {

    private float time;
    private Text text;
	// Use this for initialization
	void Start () {
        time = Time.time;
        text = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.color = new Vector4(text.color.r, text.color.g, text.color.b, Mathf.Sin(Time.time*4));
	}
}
