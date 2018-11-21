using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMP45 : MonoBehaviour, IShootable {

	// Use this for initialization
    private float timeUntilFire = 0;
    Transform firePoint;
    public GameObject bullet;
    public GameObject GunShot;
    public GameObject WeaponSplash;
    public GameObject Shells;
    public GameObject ReloadSound;
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

    void Start ()
    {
        ID = 2;
        damage = 3;
        fireRate = 0.1f;
        speed = 20f;
        magazineCapacity = 30;
        ammo = this.gameObject.GetComponent<Inventory>().rifleAmmo;
        ammoInMagazine = magazineCapacity;
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
            if (ammo > 0 && ammoInMagazine != magazineCapacity)
            {
                _reloadSoundCopy = Instantiate(ReloadSound, this.transform.position, this.transform.rotation);
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
            if (ammoInMagazine > 0 && _reloadSoundCopy == null)
            {
                Instantiate(GunShot, this.transform.position, this.transform.rotation);
                Instantiate(Shells,
                    new Vector3(firePoint.position.x, firePoint.position.y - 0.3f, firePoint.position.z),
                    this.transform.rotation *Quaternion.Euler(0, 90, 0));
                Shoot();
                timeUntilFire = Time.time + fireRate;
            }
            else
            {
                //wyswietlkomunikat()
            }
        }
    }

    public void Shoot()
    {
        Instantiate(WeaponSplash, firePoint.position, Quaternion.identity);
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

    public void DeafultAmmo()
    {
        ammoInMagazine = magazineCapacity;
    }
}
