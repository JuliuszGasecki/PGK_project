using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float speed { set; get; }
    private Vector2 direction;
    private Vector2 directionHero;
    private Vector3 mousePosition;
    private Transform _myTransform;
    private bool isWalking;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        setSetting();
    }

    void setSetting()
    {
        _myTransform = this.GetComponent<Hero>().transform;
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

    void move()
    {
        Vector2 normalizedVector = direction.normalized;
       /* if (normalizedVector.y < 0)
        {
            if (Input.GetKey(KeyCode.W))
            {

                if (this.GetComponent<Hero>().canShoot)
                {
                    anim.SetBool("isWalking", true);
                }
                this.transform.position -= new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                if (this.GetComponent<Hero>().canShoot)
                {
                    anim.SetBool("isWalking", true);
                }
                this.transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
            }
        }
        else*/
        
            if (Input.GetKey(KeyCode.W))
            {

                if (this.GetComponent<Hero>().canShoot)
                {
                    anim.SetBool("isWalking", true);
                }
                this.transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                if (this.GetComponent<Hero>().canShoot)
                {
                    anim.SetBool("isWalking", true);
                }
                this.transform.position -= new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
            }
        
        if (Input.GetKey(KeyCode.D))
        {
            if (this.GetComponent<Hero>().canShoot)
            {
                anim.SetBool("isWalking", true);
            }
            this.transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (this.GetComponent<Hero>().canShoot)
            {
                anim.SetBool("isWalking", true);
            }
            this.transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }

        
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            if (this.GetComponent<Hero>().canShoot)
            {

                anim.SetBool("isWalking", false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        speed = this.GetComponent<Hero>().speed;
        faceMouse();
        move();
    }
}
