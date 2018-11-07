using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BounceAndAdd : MonoBehaviour {

    private float angle = 0;
    private Hero hero;

    private IWeapon weapon;
    private bool _isWeapon;
    private bool _isAmmo;
    private Inventory inv;

    private string[] _weaponNames = {"DEAGLE", "UMP45", "M4", "M9", "SPAS"};

    private string[] _ammoNames = {"RifleAmmo", "ShotgunAmmo", "DeagleAmmo"};
    // Use this for initialization
    void Start ()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        var downloadStrings = this.gameObject.name.Split(new [] { ' ' }, 2);
        string name = downloadStrings[0];
        if (_weaponNames.Contains(name))
        {
            _isWeapon = true;
            weapon = GameObject.Find("Inventory").GetComponent(name) as IWeapon;
            _isAmmo = false;
        }

        else if (_ammoNames.Contains(name))
        {
            _isWeapon = false;
            _isAmmo = true;
        }
        Debug.Log(_isAmmo);
    }
	
	// Update is called once per frame
	void Update ()
	{
	    bounce();
	}

    private void bounce()
    {
        float lastY = transform.position.y;
        transform.position = new Vector3(transform.position.x, lastY + Mathf.Sin(angle) / 80, transform.position.z);
        angle += 3.14f / 64f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (_isWeapon)
                    inv.GetInventory().Add(weapon);
                destroyObject();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && _isAmmo)
        {
            if (name.Equals(_ammoNames[0]))
            {
                inv.rifleAmmo += 20;
            }
            if (name.Equals(_ammoNames[1]))
            {
                inv.rifleAmmo += 5;
            }
            if (name.Equals(_ammoNames[2]))
            {
                inv.rifleAmmo += 3;
            }
            destroyObject();
        }
    }

    private void destroyObject()
    {
        Destroy(gameObject);
    }
}
