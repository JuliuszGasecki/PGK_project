using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTest : MonoBehaviour {

	// Use this for initialization
    public float fireRate = 10;
    private float timeUntilFire = 0;
    Transform firePoint;
    public GameObject bullet;
	void Start () {
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
	        if (Input.GetMouseButtonDown(0) && Time.time > timeUntilFire)
	        {
	            timeUntilFire = Time.time + 1 / fireRate;
	            Shoot();
	        }
	   
	}

    void Shoot()
    {
      
            Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
