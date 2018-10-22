using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float speed { set; get; }
    private Vector2 direction;
    private Vector3 mousePosition;
    public Hero hero;
    private Transform _myTransform;

    // Use this for initialization
    void Start ()
    {
        setSetting();
    }

    void setSetting()
    {
        _myTransform = hero.transform;
        if (_myTransform == null)
        {
            Debug.LogError("No Player");
        }
    }

    void faceMouse()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = new Vector2(
            mousePosition.x - _myTransform.position.x,
            mousePosition.y - _myTransform.position.y);

        transform.up = direction;
    }
    

    Vector2 normalizationVector(Vector2 vector)
    {
        float x = vector.x;
        float y = vector.y;
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

    Vector2 perpendicualrVector(Vector2 vector)
    {
        return new Vector2(-vector.y, vector.x);
    }
    void move()
    {
        Vector2 normalizedVector = normalizationVector(direction);
        float pVX = perpendicualrVector(normalizedVector).x;
        float pVY = perpendicualrVector(normalizedVector).y;
        if (Input.GetKey(KeyCode.W))
            transform.position += new Vector3(normalizedVector.x * speed * Time.deltaTime,
                normalizedVector.y * speed * Time.deltaTime, 0.0f);
        if (Input.GetKey(KeyCode.S))
            transform.position -= new Vector3(normalizedVector.x * speed * Time.deltaTime,
                normalizedVector.y * speed * Time.deltaTime, 0.0f);
        if (normalizedVector.y < 0)
        {
            if (Input.GetKey(KeyCode.D))
                transform.position += new Vector3(pVX * speed * Time.deltaTime, pVY * speed * Time.deltaTime, 0.0f);
            if (Input.GetKey(KeyCode.A))
                transform.position -= new Vector3(pVX * speed * Time.deltaTime, pVY * speed * Time.deltaTime, 0.0f);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
                transform.position -= new Vector3(pVX * speed * Time.deltaTime,
                    pVY * speed * Time.deltaTime, 0.0f);
            if (Input.GetKey(KeyCode.A))
                transform.position += new Vector3(pVX * speed * Time.deltaTime,
                    pVY * speed * Time.deltaTime, 0.0f);
        }
    }
	
	// Update is called once per frame
	void Update ()
	{
	    speed = hero.speed;
        faceMouse();
	    move();
	}
}
