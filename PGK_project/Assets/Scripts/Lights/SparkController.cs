using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SparkController : MonoBehaviour
{
    private float _time;

    private int _SparkPause;

    private System.Random rng;
	// Use this for initialization
	void Start ()
	{
        rng = new System.Random();
	    _time = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _SparkPause = rng.Next(7, 10);
	    if (Time.time > _time + _SparkPause)
	    {
	        gameObject.GetComponent<ParticleSystem>().Play();
            _time = Time.time;
	    }
	}
}
