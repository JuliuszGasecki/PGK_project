using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    public float speed = 2.0f;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
        if(Input.GetKey(KeyCode.D))
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
	    if (Input.GetKey(KeyCode.A))
	        transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
	    if (Input.GetKey(KeyCode.W))
	        transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
	    if (Input.GetKey(KeyCode.S))
	        transform.position -= new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
    }
}
