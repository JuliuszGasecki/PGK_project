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
    private Animator anim;
    private Hero hero;
    public GameObject FlashEffect1;
    public GameObject FlashEffect2;
    private Rigidbody2D _heroRigidbody2D;

    // Use this for initialization
    void Start()
    {
        hero = GetComponent<Hero>();
        anim = GetComponent<Animator>();
        setSetting();
        _heroRigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
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
        if (hero.isAlive())
        {
            direction = new Vector2(
                mousePosition.x - _myTransform.position.x,
                mousePosition.y - _myTransform.position.y);

            transform.up = direction;
        }
    }

   /* void PlayAnimation()
    {
        if (_heroRigidbody2D.velocity.magnitude > 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
            anim.SetBool("isWalking", false);
    }*/

    void move()
    {
        Vector2 normalizedVector = direction.normalized;

        if (hero.isAlive())
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
                Input.GetKey(KeyCode.A))
            {
                directionHero = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                directionHero.Normalize();
                transform.Translate(directionHero * Time.deltaTime * speed, Space.World);
                anim.SetBool("isWalking", true);
            }


           if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) ||
                Input.GetKeyUp(KeyCode.A))
           {                
                anim.SetBool("isWalking", false);              
           }
        }
    }

    public void flash()
    {
        Instantiate(FlashEffect2, this.gameObject.transform.position, Quaternion.identity);
        Instantiate(FlashEffect1, this.gameObject.transform.position, Quaternion.identity);
        
        transform.position = new Vector3(transform.position.x + directionHero[0] *3.5f , transform.position.y + directionHero[1] *5 * 3.5f, transform.position.z);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = this.GetComponent<Hero>().speed;
        faceMouse();
        move();
      //  PlayAnimation();
    }
}
