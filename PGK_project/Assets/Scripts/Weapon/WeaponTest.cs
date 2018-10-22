using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTest : MonoBehaviour {

	// Use this for initialization
    public float fireRate = 10;
    private float timeUntilFire = 0;
    Transform firePoint;
    public GameObject bullet;
    private float colliderOffset;
    private float tempColliderOffset;
    private Vector2 collider;
    private bool isHit;
	void Start ()
	{
	    collider = this.gameObject.GetComponent<CircleCollider2D>().offset;
	}

    void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No FirePoint!");
        }
    }
	// Update is called once per frame
	void Update ()
    { 
	        if (Input.GetMouseButtonDown(0) && Time.time > timeUntilFire && this.GetComponent<Hero>().canShoot)
	        {
	            timeUntilFire = Time.time + 1 / fireRate;
	            Shoot();
	        }

        if (Input.GetMouseButtonDown(0) && !this.GetComponent<Hero>().canShoot)
        {
            Attack();
        }
	   
	}

    void Attack()
    {
        colliderOffset = collider.y;
        collider.y += 4.0f;
        collider.y = colliderOffset;
    }

    void Shoot()
    {
      
            Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            isHit = false;
        }

        
    }
}
