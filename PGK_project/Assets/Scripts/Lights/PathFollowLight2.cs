using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowLight2 : MonoBehaviour {

    public Transform[] waypoints;
    public float moveSpeed;
    int current = 0;
    float time;


	// Use this for initialization
	void Start () {
        time = Time.time;
        transform.position = waypoints[current].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        time = Time.time;
	}

   
    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, moveSpeed * (Time.time - time));

        if(transform.position == waypoints[current].transform.position)
        {
            current += 1;
        }

        if(current == waypoints.Length)
        {
            current = 0;
        }

    }
}
