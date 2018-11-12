using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjectAfterSplash : MonoBehaviour
{
    private float time;
	// Use this for initialization
	void Start ()
	{
	    time = this.gameObject.GetComponent<ParticleSystem>().main.duration;
	}
	
	// Update is called once per frame
	void Update () {
	    time -= Time.deltaTime;
	    if (time <= 0f)
	    {
	        Destroy(this.gameObject);
	    }
    }
}
