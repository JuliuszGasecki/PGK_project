using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPAS : MonoBehaviour, IShootable
{
    // Use this for initialization
    public float timeToResetAlert;
    private float timerToResetAlert;
    private float timeUntilFire = 0;
    Transform firePoint;
    public GameObject bullet;
    public GameObject GunShot;
    public GameObject ReloadSound;
    public GameObject Shells;
    public float fireRate { get; set; }
    public int damage { get; set; }
    public int ID { get; set; }
    public float speed { get; set; }
    public int magazineCapacity { set; get; }
    public int ammo { get; set; }
    public int ammoInMagazine { get; set; }
    public bool CanUse { get; set; }
    public bool alert { set; get; }

    public string Name { get; set; }
    private Animator anim;
    private Vector2 direction;
    private Vector3 mousePosition;

    void Start()
    {
        anim = GameObject.Find("Hero").GetComponent<Animator>();
        ID = 3;
        damage = 10;
        fireRate = 0.7f;
        speed = 20f;
        magazineCapacity = 9;
        ammo = this.gameObject.GetComponent<Inventory>().shotgunAmmo;
        ammoInMagazine = magazineCapacity;
        Name = "SPAS";
        alert = false;
    }

    void Awake()
    {
        firePoint = transform.Find("FirePoint2");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timerToResetAlert > timeToResetAlert)
            alert = false;
        if (firePoint != null)
        {
            AutoReloading();
            //Reload();
            UseWeapon();
            UpdateAmmo();
        }
    }

    /*public void Reload()
    {
        int difference;
        if (Input.GetKeyDown(KeyCode.R) && CanUse)
        {         
            if (ammo > 0 && ammoInMagazine != magazineCapacity)
            {
                Instantiate(ReloadSound, this.transform.position, this.transform.rotation);
                difference = magazineCapacity - ammoInMagazine;
                if (difference > ammo)
                {
                    ammoInMagazine += ammo;
                    this.gameObject.GetComponent<Inventory>().shotgunAmmo = 0;
                }
                else
                {
                    ammoInMagazine += difference;
                    this.gameObject.GetComponent<Inventory>().shotgunAmmo -= difference;
                }
            }

        }
    }*/

    public void AutoReloading()
    {
        if ((ammoInMagazine == 0 || Input.GetKeyDown(KeyCode.R)) && CanUse && ammo > 0 &&
            ammoInMagazine != magazineCapacity)
        {
            Instantiate(ReloadSound, this.transform.position, this.transform.rotation);
            var difference = magazineCapacity - ammoInMagazine;
            if (difference > ammo)
            {
                ammoInMagazine += ammo;
                this.gameObject.GetComponent<Inventory>().shotgunAmmo = 0;
            }
            else
            {
                ammoInMagazine += difference;
                this.gameObject.GetComponent<Inventory>().shotgunAmmo -= difference;
            }
        }
    }


    void Direction()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);
        direction.Normalize();
    }

    public void UseWeapon()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > timeUntilFire && CanUse)
        {
            if (ammoInMagazine > 0)
            {
                alert = true;
                Direction();
                Instantiate(GunShot, this.transform.position, this.transform.rotation);
                if (direction.y < 0)
                {
                    Instantiate(Shells,
                        new Vector3(firePoint.position.x, firePoint.position.y + 0.45f,
                            firePoint.position.z),
                        this.transform.rotation * Quaternion.Euler(0, 90, 0));
                }
                else
                {
                    Instantiate(Shells,
                        new Vector3(firePoint.position.x, firePoint.position.y - 0.45f,
                            firePoint.position.z),
                        this.transform.rotation * Quaternion.Euler(0, 90, 0));
                }

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
        float x = 0.0f;
        float y = 0.0f;
        if (direction.y < 0)
        {
            x = 0.15f;
        }
        else
        {
            x = -0.15f;
        }

        if (direction.x < 0)
        {
            y = -0.15f;
        }
        else
        {
            y = 0.15f;
        }

        GameObject bullet1 = Instantiate(bullet,firePoint.position, firePoint.rotation);
        SetDamageBullet(bullet1);
        SetSpeedBullet(bullet1);
        GameObject bullet2 = Instantiate(bullet, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, -15));
        SetDamageBullet(bullet2);
        SetSpeedBullet(bullet2);
        GameObject bullet3 = Instantiate(bullet, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 15));
        SetDamageBullet(bullet3);
        SetSpeedBullet(bullet3);
        ammoInMagazine -= 3;
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
        ammo = this.gameObject.GetComponent<Inventory>().shotgunAmmo;
    }

    public void DeafultAmmo()
    {
        ammoInMagazine = magazineCapacity;
    }
}