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
    public int magazineCapacity { set; get; }
    public int ammo { get; set; }
    public int ammoInMagazine { get; set; }

    void Start ()
    {
        ID = 1;
        damage = 5;
        fireRate = 10f;
        speed = 20f;
        magazineCapacity = 30;
        ammo = 40;
        ammoInMagazine = 0;
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
        Reload();
        UseWeapon();
    }

    public void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ammo > magazineCapacity)
            {
                ammoInMagazine = magazineCapacity;
                ammo -= magazineCapacity;
            }
            else
            {
                ammoInMagazine = ammo;
                ammo = 0;
            }
        }
    }



    public void UseWeapon()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > timeUntilFire && this.GetComponent<Hero>().canShoot)
        {
            if (ammoInMagazine > 0)
            {
                Shoot();
                timeUntilFire = Time.time + 1 / fireRate;
            }
            else
            {
                //wyswietlkomunikat()
            }
        }
    }

    public void Shoot()
    {    
        GameObject bulletM4 = Instantiate(bullet, firePoint.position, firePoint.rotation);
        SetDamageBullet(bulletM4);
        SetSpeedBullet(bulletM4);
        ammoInMagazine--;
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
