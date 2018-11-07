﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMP45 : MonoBehaviour, IShootable {

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
    public bool CanUse { get; set; }

    public string Name { get; set; }

    void Start ()
    {
        ID = 2;
        damage = 5;
        fireRate = 10f;
        speed = 20f;
        magazineCapacity = 30;
        ammo = this.gameObject.GetComponent<Inventory>().rifleAmmo;
        ammoInMagazine = 0;
        Name = "UMP45";
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
        UpdateAmmo();
    }

    public void Reload()
    {
        int difference;
        if (Input.GetKeyDown(KeyCode.R) && CanUse)      
        {
            if (ammo > 0)
            {
                difference = magazineCapacity - ammoInMagazine;
                if (difference > ammo)
                {
                    ammoInMagazine += ammo;
                    this.gameObject.GetComponent<Inventory>().rifleAmmo = 0;
                }
                else
                {
                    ammoInMagazine += difference;
                    this.gameObject.GetComponent<Inventory>().rifleAmmo -= difference;
                }
            }

        }
    }


    public void UseWeapon()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > timeUntilFire && CanUse)
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

    public string DisplayToTextAmmo()
    {
        string display = ammoInMagazine.ToString() + "/" + ammo.ToString();
        return display;
    }

    public void UpdateAmmo()
    {
        ammo = this.gameObject.GetComponent<Inventory>().rifleAmmo;
    }
}