using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowLight : MonoBehaviour {

    public Transform[] path;
    public float speed;
    public float reachDist;
    public int currentPoint = 0;
    private float time;
	// Use this for initialization
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = path[currentPoint].position - transform.position;
        transform.position += dir * (Time.time - time)* speed;
        time = Time.time;
        Debug.Log(transform.position);

        if (dir.magnitude <= reachDist)
        {
            currentPoint++;
        }

        if(currentPoint >= path.Length)
        {
            currentPoint = 0;
        }
    }

    void OnDrawGizmos()
    {
        if(path.Length >0)
            for(int i = 0; i < path.Length; i++)
            {
                if(path[i] != null)
                {
                    Gizmos.DrawSphere(path[i].position, reachDist);
                }
            }
    }

}
