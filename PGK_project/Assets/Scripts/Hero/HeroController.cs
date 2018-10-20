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

    Vector2 ogarnij_cipe_2(Vector2 twoja_stara)
    {
        return new Vector2(-twoja_stara.y, twoja_stara.x);
    }
    void move()
    {
        Vector2 ogar = ogarnij_cipe(direction);
        if (Input.GetKey(KeyCode.W))
            transform.position += new Vector3(ogar.x * speed * Time.deltaTime,
                ogar.y * speed * Time.deltaTime, 0.0f);
        if (Input.GetKey(KeyCode.S))
            transform.position -= new Vector3(ogar.x * speed * Time.deltaTime,
                ogar.y * speed * Time.deltaTime, 0.0f);
        if (direction.y < 0)
        {
            if (Input.GetKey(KeyCode.D))
                transform.position += new Vector3(ogarnij_cipe_2(ogar).x * speed * Time.deltaTime, ogarnij_cipe_2(ogar).y * speed * Time.deltaTime, 0.0f);
            if (Input.GetKey(KeyCode.A))
                transform.position -= new Vector3(ogarnij_cipe_2(ogar).x * speed * Time.deltaTime, ogarnij_cipe_2(ogar).y * speed * Time.deltaTime, 0.0f);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
                transform.position -= new Vector3(ogarnij_cipe_2(ogar).x * speed * Time.deltaTime,
                    ogarnij_cipe_2(ogar).y * speed * Time.deltaTime, 0.0f);
            if (Input.GetKey(KeyCode.A))
                transform.position += new Vector3(ogarnij_cipe_2(ogar).x * speed * Time.deltaTime,
                    ogarnij_cipe_2(ogar).y * speed * Time.deltaTime, 0.0f);
        }
    }
	
	// Update is called once per frame
	void Update ()
	{
	    faceMouse();
	    move();
	}
}
