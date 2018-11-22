using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEAGLE : MonoBehaviour, IShootable
{

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
    private Animator anim;

    void Start()
    {
        anim = GameObject.Find("Hero").GetComponent<Animator>();
        ID = 0;
        damage = 10;
        fireRate = 1f;
        speed = 20f;
        magazineCapacity = 7;
        ammo = this.gameObject.GetComponent<Inventory>().deagleAmmo; 
        ammoInMagazine = magazineCapacity;
        Name = "DEAGLE";
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
    void Update()
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
                anim.SetBool("loading", true);
                difference = magazineCapacity - ammoInMagazine;
                if (difference > ammo)
                {
                    ammoInMagazine += ammo;
                    this.gameObject.GetComponent<Inventory>().deagleAmmo = 0;
                }
                else
                {
                    ammoInMagazine += difference;
                    this.gameObject.GetComponent<Inventory>().deagleAmmo -= difference;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.R) && CanUse)
        {
            anim.SetBool("loading", false);
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
                    this.transform.rotation * Quaternion.Euler(0, 90, 0));
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
        GameObject bulletD = Instantiate(bullet, firePoint.position, firePoint.rotation);
        SetDamageBullet(bulletD);
        SetSpeedBullet(bulletD);
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
        ammo = this.gameObject.GetComponent<Inventory>().deagleAmmo;
    }

    public void DeafultAmmo()
    {
        ammoInMagazine = magazineCapacity;
    }
}
