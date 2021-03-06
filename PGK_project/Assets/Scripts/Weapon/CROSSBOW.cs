﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject AmmoIcon;
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
    private List<GameObject> ammoIcons;

    public int NarcoMixId { set; get; }

    // private Vector2 direction;
    private Vector3 mousePosition;

    private enum _specialEffect
    {
        GreenArrows,
        RedArrows
    }

    void Start()
    {
        ammoIcons = new List<GameObject>();
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
            NarcoMixId = GameObject.Find("Inventory").GetComponent<Inventory>().ReturnDrugsMix();
           // Debug.Log(NarcoMixId);
            UpdateAmmo();
            UseWeapon();
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
        Destroy(ammoIcons[0]);
        ammoIcons.RemoveAt(0);
        for (int i = 0; i < ammoIcons.Count; i++)
        {
            ammoIcons[i].transform.localPosition = new Vector3(
                ammoIcons[i].GetComponent<DispalySpecialWeaponAmmo>().FirstPosX +
                50.0f * (i+1),
                ammoIcons[i].GetComponent<DispalySpecialWeaponAmmo>().FirstPosY, 0.0f);
        }
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
        if (Enum.IsDefined(typeof(_specialEffect), NarcoMixId))
        {
            ammoInMagazine++;
            ammoIcons.Add(Instantiate(AmmoIcon));
            GameObject lastGameObject = ammoIcons.Last();
            lastGameObject.GetComponent<DispalySpecialWeaponAmmo>().indexArrow = NarcoMixId;
            lastGameObject.transform.SetParent(GameObject.Find("Canvas").transform);
            lastGameObject.transform.localPosition =
                new Vector3(
                    lastGameObject.GetComponent<DispalySpecialWeaponAmmo>().FirstPosX -
                    lastGameObject.GetComponent<DispalySpecialWeaponAmmo>().Width * (ammoIcons.Count - 1),
                    lastGameObject.GetComponent<DispalySpecialWeaponAmmo>().FirstPosY, 0.0f);
        }
    }

    public void DeafultAmmo()
    {
        ammoInMagazine = magazineCapacity;
    }

    public void SetSpecialEffect(GameObject bullet)
    {
        if (Enum.IsDefined(typeof(_specialEffect), NarcoMixId))
        {
            bullet.GetComponent<CrossbowBullet>().specialEffect = NarcoMixId;
        }
    }
}