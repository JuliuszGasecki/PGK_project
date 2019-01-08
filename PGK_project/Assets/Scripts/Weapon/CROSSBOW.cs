﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CROSSBOW : MonoBehaviour, ISpecialWeapon
{

    // Use this for initialization
    private float timeUntilFire = 0;
    Transform firePoint;
    public GameObject bullet;
    public GameObject GunShot;
    public GameObject ReloadSound;
    private DrugsTimer drugsStats;
    private GameObject _reloadSoundCopy;
    public float fireRate { get; set; }
    public int damage { get; set; }
    public int ID { get; set; }
    public float speed { get; set; }
    public int magazineCapacity { set; get; }
    public int ammo { get; set; }
    public int ammoInMagazine { get; set; }
    public bool CanUse { get; set; }
    public string Name { get; set; }
    public bool alert { set; get; }
    private Animator anim;

    private int narcoMixId;
   // private Vector2 direction;
    private Vector3 mousePosition;
    private enum _specialEffect
    {
        GreenArrows,
        RedArrows
    }

    void Start()
    {
        anim = GameObject.Find("Hero").GetComponent<Animator>();
        ID = 5;
        damage = 0;
        fireRate = 0.6f;
        speed = 25f;
        magazineCapacity = 10000;
        ammoInMagazine = 0;
        Name = "CROSSBOW";
    }

    void Awake()
    {
        firePoint = transform.Find("FirePoint");

    }
    // Update is called once per frame
    void Update()
    {
        if (firePoint != null)
        {
            narcoMixId = this.gameObject.GetComponent<Inventory>().ReturnDrugsMix();
            Debug.Log(narcoMixId);
            //AutoReloading();
            //  Reload();
            UseWeapon();
            UpdateAmmo();
        }
    }

    public void AutoReloading()
    {   
    }

    public void UseWeapon()
    {
        if (Input.GetMouseButtonDown(2) && Time.time > timeUntilFire && CanUse)
        {
            if (ammoInMagazine > 0 && _reloadSoundCopy == null)
            {
                Instantiate(GunShot, this.transform.position, this.transform.rotation);
                Shoot();
                timeUntilFire = Time.time + fireRate;
            }
        }
    }

    public void Shoot()
    {
        GameObject bulletC = Instantiate(bullet, firePoint.position, firePoint.rotation);
        SetSpecialEffect(bulletC);
        SetSpeedBullet(bulletC);
        ammoInMagazine--;
    }
    public void SetDamageBullet(GameObject bullet)
    {     
    }

    public void SetSpeedBullet(GameObject bullet)
    {
        bullet.GetComponent<CrossbowBullet>().bulletSpeed = speed;
    }

    public string DisplayToTextAmmo()
    {
        string display = ammoInMagazine.ToString();
        return display;
    }

    public void UpdateAmmo()
    {
        if (Enum.IsDefined(typeof(_specialEffect), narcoMixId))
        {
            ammoInMagazine++;
        }
    }

    public void DeafultAmmo()
    {
        ammoInMagazine = magazineCapacity;
    }

    public void SetSpecialEffect(GameObject bullet)
    {   
        if (Enum.IsDefined(typeof(_specialEffect), narcoMixId))
        {
            ammoInMagazine++;
            bullet.GetComponent<CrossbowBullet>().specialEffect = narcoMixId;
        }
    }

}
