using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<RectTransform>().position =
            new Vector3(this.GetComponent<RectTransform>().position.x,
            this.GetComponent<RectTransform>().position.y + 1.0f,
            this.GetComponent<RectTransform>().position.z);
    }
}
