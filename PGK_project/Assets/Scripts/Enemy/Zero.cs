using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zero : MonoBehaviour {
    public float level;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, level); ;
	}
}
