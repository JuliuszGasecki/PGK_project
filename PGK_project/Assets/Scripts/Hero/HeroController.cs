using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float speed = 2.0f;

    private Vector3 mousePosition;
    // Use this for initialization
    void Start ()
	{
	}

    void faceMouse()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);

        transform.up = direction;
    }

    void move()
    {
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.A))
            transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.W))
            transform.position += new Vector3((mousePosition.x - transform.position.x) * speed * Time.deltaTime, (mousePosition.y - transform.position.y) * speed * Time.deltaTime,  0.0f);
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
