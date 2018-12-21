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


    void Start()
    {
        anim = GameObject.Find("Hero").GetComponent<Animator>();
        ID = 5;
        damage = 10;
        fireRate = 0.6f;
        speed = 25f;
        magazineCapacity = 5;
        ammoInMagazine = magazineCapacity;
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
            AutoReloading();
            //  Reload();
            UseWeapon();
            UpdateAmmo();
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
        if (ammoInMagazine == 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    public void UseWeapon()
    {
        if (Input.GetMouseButtonDown(2) && Time.time > timeUntilFire && CanUse)
        {
            if (ammoInMagazine > 0 && _reloadSoundCopy == null)
            {
                Direction();
                Instantiate(GunShot, this.transform.position, this.transform.rotation);
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
        GameObject bulletC = Instantiate(bullet, firePoint.position, firePoint.rotation);
        SetDamageBullet(bulletC);
        SetSpeedBullet(bulletC);
        ammoInMagazine--;
    }
    public void SetDamageBullet(GameObject bullet)
    {
        bullet.GetComponent<CrossbowBullet>().bulletDamage = damage;
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
        ammo = this.gameObject.GetComponent<Inventory>().deagleAmmo;
    }

    public void DeafultAmmo()
    {
        ammoInMagazine = magazineCapacity;
    }

    public void SetSpecialEffect()
    {
        
    }
}
