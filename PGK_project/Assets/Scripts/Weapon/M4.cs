using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4 : MonoBehaviour, IShootable {

	// Use this for initialization
    private float timeUntilFire = 0;
    Transform firePoint;
    public GameObject bullet;

    public float fireRate { get; set; }
    public int damage { get; set; }
    public int ID { get; set; }
    public float speed { get; set; }

    void Start ()
    {
        ID = 1;
        damage = 5;
        fireRate = 10f;
        speed = 20f;
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
    }

    void Shoot()
    {   
       GameObject bulletM4 = Instantiate(bullet, firePoint.position, firePoint.rotation);
       SetDamageBullet(bulletM4);
       SetSpeedBullet(bulletM4);
    }
    public void SetDamageBullet(GameObject bullet)
    {
        bullet.GetComponent<Bullet>().bulletDamage = damage;
    }

    public void SetSpeedBullet(GameObject bullet)
    {
        bullet.GetComponent<Bullet>().bulletSpeed = speed;
    }
}
