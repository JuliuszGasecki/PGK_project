using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMP45 : MonoBehaviour, IShootable {

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
    private Animator anim;
    private Vector2 direction;
    private Vector3 mousePosition;
    public bool alert { set; get; }

    private float time;
    private bool isAnimOn = false;

    public string Name { get; set; }

    void Start ()
    {
        anim = GameObject.Find("Hero").GetComponent<Animator>();
        ID = 2;
        damage = 3;
        fireRate = 0.1f;
        speed = 25f;
        magazineCapacity = 30;
        ammo = this.gameObject.GetComponent<Inventory>().RifleAmmo;
        ammoInMagazine = magazineCapacity;
        Name = "UMP45";
        alert = false;
    }

    void Awake()
    {
        firePoint = transform.Find("FirePoint2");

    }
	// Update is called once per frame
	void Update ()
	{
        if (Time.time - timerToResetAlert > timeToResetAlert)
            alert = false;
        if (firePoint != null)
	    {
	        AutoReloading();
	        //Reload();
	        UseWeapon();
	        UpdateAmmo();
            setAnim();
        }
	}

    public void AutoReloading()
    {
        if ((ammoInMagazine == 0 || Input.GetKeyDown(KeyCode.R)) && CanUse && ammo > 0 && ammoInMagazine != magazineCapacity)
        {
            _reloadSoundCopy = Instantiate(ReloadSound, this.transform.position, this.transform.rotation);
            var difference = magazineCapacity - ammoInMagazine;
            if (difference > ammo)
            {
                ammoInMagazine += ammo;
                this.gameObject.GetComponent<Inventory>().RifleAmmo = 0;
                //anim.SetBool("loading", true);
            }
            else
            {
                ammoInMagazine += difference;
                this.gameObject.GetComponent<Inventory>().RifleAmmo -= difference;
                //anim.SetBool("loading", true);
            }
            //anim.SetBool("loading", true);
            time = Time.time;
            isAnimOn = true;
        }
        //anim.SetBool("loading", false);
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
            if (ammoInMagazine > 0 && _reloadSoundCopy == null)
            {
                Direction();
                Instantiate(GunShot, this.transform.position, this.transform.rotation);
                alert = true;
                if (direction.y < 0)
                {
                    Instantiate(Shells,
                        new Vector3(firePoint.position.x, firePoint.position.y + 0.35f, firePoint.position.z),
                        this.transform.rotation * Quaternion.Euler(0, 90, 0));
                }
                else
                {
                    Instantiate(Shells,
                        new Vector3(firePoint.position.x, firePoint.position.y - 0.35f, firePoint.position.z),
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
        GameObject _weaponSplash = Instantiate(WeaponSplash, firePoint.position, Quaternion.identity);
        _weaponSplash.transform.parent = GameObject.Find("Hero").transform;
        _weaponSplash.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        GameObject bulletM4 = Instantiate(bullet, new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z), firePoint.rotation);
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
        ammo = this.gameObject.GetComponent<Inventory>().RifleAmmo;
    }

    public void DeafultAmmo()
    {
        ammoInMagazine = magazineCapacity;
    }
}
