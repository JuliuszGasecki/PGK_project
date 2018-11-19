using System;
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

    private string[] _weaponNames = { "DEAGLE", "UMP45", "M4", "M9", "SPAS"};

    private string[] _ammoNames = {"RifleAmmo", "ShotgunAmmo", "DeagleAmmo"};

    private string nameW;
    // Use this for initialization
    void Start ()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        var downloadStrings = this.gameObject.name.Split(new [] { '(' }, 2);
        nameW = downloadStrings[0];
        nameW = nameW.Replace(" ", string.Empty);
        if (_weaponNames.Contains(nameW))
        {
            _isWeapon = true;
            weapon = GameObject.Find("Inventory").GetComponent(nameW) as IWeapon;
            _isAmmo = false;
        }

        else if (_ammoNames.Contains(nameW))
        {
            _isWeapon = false;
            _isAmmo = true;
        }
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
        if (collision.tag == "Player" )
        {
            
            if (Input.GetKeyDown(KeyCode.E) && _isWeapon)
            {
                if (inv.IsAdded(weapon.ID))
                    AddAmmoInsteadOf();
                else
                    inv.AddToList(weapon);
                destroyObject();
            }
            else if (_isAmmo)
            {
                AddAmmo();
                destroyObject();
            }
        }
    }

    private void AddAmmoInsteadOf()
    {

        if (nameW.Equals(_weaponNames[0]))
        {
            inv.deagleAmmo += 3;
            return;
        }
        if (nameW.Equals(_weaponNames[1]))
        {
            inv.rifleAmmo += 20;
            return;
        }
        if(nameW.Equals(_weaponNames[2]))
        {
            inv.rifleAmmo += 20;
            return;
        }
        if(nameW.Equals(_weaponNames[4]))
        {
            inv.shotgunAmmo += 5;
            return;
        }
    }

    private void AddAmmo()
    {
        if (nameW.Equals(_ammoNames[0]))
        {
            inv.rifleAmmo += 150;
        }
        else if (nameW.Equals(_ammoNames[1]))
        {
            inv.shotgunAmmo += 5;
        }
        else if (nameW.Equals(_ammoNames[2]))
        {
            inv.deagleAmmo += 3;
        }
    }
    
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && _isAmmo)
        {
            Debug.Log("xDDDDDDDDDD");
            AddAmmo();
            destroyObject();
        }
    }*/

    private void destroyObject()
    {
        Destroy(gameObject);
    }
}
