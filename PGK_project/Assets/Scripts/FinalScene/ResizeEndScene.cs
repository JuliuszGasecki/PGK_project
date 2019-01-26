using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeEndScene : MonoBehaviour {

    private float time;
	// Use this for initialization
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<RectTransform>().position = 
            new Vector3(this.GetComponent<RectTransform>().position.x,
            this.GetComponent<RectTransform>().position.y - 0.005f,
            this.GetComponent<RectTransform>().position.z);
        this.GetComponent<RectTransform>().localScale =
            new Vector3(this.GetComponent<RectTransform>().localScale.x + 0.001f,
            this.GetComponent<RectTransform>().localScale.y + 0.001f,
            this.GetComponent<RectTransform>().localScale.z + 0.001f);

    }
}
