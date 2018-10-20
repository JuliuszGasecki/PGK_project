using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Vector3 mousePosition;
 

    // Use this for initialization
    void Start ()
	{
    
    }

    void faceMouse()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);

        transform.up = direction;
    }
    

    Vector2 ogarnij_cipe(Vector2 twoja_stara)
    {
        float x = twoja_stara.x;
        float y = twoja_stara.y;
        if (Mathf.Abs(x) >= Mathf.Abs(y))
        {
            y = y / Mathf.Abs(x);
            x = x / Mathf.Abs(x);
          
        }
        else if (Mathf.Abs(x) < Mathf.Abs(y))
        {
            x = x / Mathf.Abs(y);
            y = y / Mathf.Abs(y);
          }
        return new Vector2(x,y);

    }
    void move()
    {
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.A))
            transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.W))
            transform.position += new Vector3(ogarnij_cipe(direction).x * speed * Time.deltaTime,
                ogarnij_cipe(direction).y * speed * Time.deltaTime, 0.0f);
        if (Input.GetKey(KeyCode.S))
            transform.position -= new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
    }
	
	// Update is called once per frame
	void Update ()
	{
	    faceMouse();
	    move();
	}
}
