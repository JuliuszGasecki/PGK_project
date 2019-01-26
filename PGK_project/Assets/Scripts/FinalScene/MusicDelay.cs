using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDelay : MonoBehaviour {

    float time = 0;
    public float whatTime;
    bool musicFlag = false;
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - time > whatTime && musicFlag != true )
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            musicFlag = true;
        }
	}
}
