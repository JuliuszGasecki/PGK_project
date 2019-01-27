using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEAGLE : MonoBehaviour, IShootable
{

    // Use this for initialization
    public float timeToResetAlert;
    private float timerToResetAlert;
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
    public bool alert { set; get; }
    private Animator anim;
    private Vector2 direction;
    private Vector3 mousePosition;

    private float time;
    private bool isAnimOn = false;


    void Start()
    {
        anim = GameObject.Find("Hero").GetComponent<Animator>();
        ID = 0;
        damage = 10;
        fireRate = 0.70f;
        speed = 25f;
        magazineCapacity = 7;
        ammo = this.gameObject.GetComponent<Inventory>().DeagleAmmo; 
        ammoInMagazine = magazineCapacity;
        Name = "DEAGLE";
        alert = false;
        timerToResetAlert = Time.time;
    }

    void Awake()
    {
        firePoint = transform.Find("FirePoint");

    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time - timerToResetAlert > timeToResetAlert)
            alert = false;
        if (firePoint != null)
        {
            AutoReloading();
            //  Reload();
            UseWeapon();
            UpdateAmmo();
            setAnim();
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
    public void AutoReloading()
    {
        if ((ammoInMagazine == 0 || Input.GetKeyDown(KeyCode.R) ) && CanUse && ammo > 0 && ammoInMagazine != magazineCapacity)
        {
            _reloadSoundCopy = Instantiate(ReloadSound, this.transform.position, this.transform.rotation);
            var difference = magazineCapacity - ammoInMagazine;
            if (difference > ammo)
            {
                ammoInMagazine += ammo;
                this.gameObject.GetComponent<Inventory>().DeagleAmmo = 0;
            }
            else
            {
                ammoInMagazine += difference;
                this.gameObject.GetComponent<Inventory>().DeagleAmmo -= difference;
            }

            time = Time.time;
            isAnimOn = true;
        }
    }

    private void setAnim()
    {
        if (isAnimOn)
        {
            anim.SetBool("loading", true);
            isAnimOn = false;
        }
        else if (Time.time - time >= 1 && time != 0)
        {
            anim.SetBool("loading", false);
            time = 0;
        }
    }

    public void UseWeapon()
    {
        if (Input.GetMouseButton(0) && Time.time > timeUntilFire && CanUse)
        {
            if (ammoInMagazine > 0 && _reloadSoundCopy == null)
            {
                alert = true;
                timerToResetAlert = Time.time;
                Direction();
                Instantiate(GunShot, this.transform.position, this.transform.rotation);
                if (direction.y < 0)
                {
                    Instantiate(Shells,
                        new Vector3(firePoint.position.x, firePoint.position.y + 0.30f, firePoint.position.z),
                        this.transform.rotation * Quaternion.Euler(0, 90, 0));
                }
                else
                {
                    Instantiate(Shells,
                        new Vector3(firePoint.position.x, firePoint.position.y - 0.30f, firePoint.position.z),
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
        GameObject _weaponSplash = Instantiate(WeaponSplash, firePoint.position, Quaternion.identity) as GameObject;
        _weaponSplash.transform.parent = GameObject.Find("Hero").transform;
        _weaponSplash.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
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
        ammo = this.gameObject.GetComponent<Inventory>().DeagleAmmo;
    }

    public void DeafultAmmo()
    {
        ammoInMagazine = magazineCapacity;
    }
}
