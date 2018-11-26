using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour {

    public float duration = 0.5f;
    Light light;
    // Use this for initialization
    void Start () {
        light = gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        float r = Mathf.Sin(duration * Time.time/4) ;
        float g = Mathf.Sin(duration * Time.time * 3.14f/4);
       light.color  = new Vector4(r / 4 + 0.75f, g/ 4 + 0.75f, 1, 1);
    }
}
