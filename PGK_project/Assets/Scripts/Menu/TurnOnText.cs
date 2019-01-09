using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnText : MonoBehaviour {

    public GameObject _gameObject;
    private float time;
    public float stopTime;
	// Use this for initialization
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - time >= stopTime)
        {
            _gameObject.SetActive(true);
        }
	}
}
