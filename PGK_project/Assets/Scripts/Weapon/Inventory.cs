using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int FIRSTELEMENT = 0;
    private const int SECONDELEMENT = 1;
    private const int THIRDELEMENT = 2;
    private const int INVENTORYCAPACITY = 3;
    private Animator _heroAnimatior;
    private int usingSlot = 0;
    public int rifleAmmo { set; get; }
    public int shotgunAmmo { set; get; }
    public int deagleAmmo { set; get; }
    private enum _weaponsID
    {
        DEAGLE,
        M4,
        UMP45,
        SPAS12,
        KNIFE
    };

    public List<IWeapon> inventory;
	// Use this for initialization
	void Start ()
	{
        //_heroAnimatior = GetComponent<Animator>();
        _heroAnimatior = GameObject.Find("Hero").GetComponent<Animator>();
	    rifleAmmo = 30;
	    shotgunAmmo = 15;
	    deagleAmmo = 10;
        inventory = new List<IWeapon>();
	    AddToList(this.gameObject.GetComponent<DEAGLE>());
        inventory.ElementAt(FIRSTELEMENT).CanUse = true;
        usingSlot = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    UseWeapon();
	    RemoveFromInventory();
	    //Debug.Log(deagleAmmo);
	}

    private void SetWeaponActivity(int avoid)
    {
        for (int i = 0; i < inventory.Count; i++)
        { 
            if (i == avoid)
            {
                inventory.ElementAt(i).CanUse = true;
                continue;
            }
            inventory.ElementAt(i).CanUse = false;
        }
    }

    private void UseWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && inventory.Count >= 1)
        {
            _heroAnimatior.SetInteger("weaponID", 1);
            _heroAnimatior.SetBool("changingWeapon", true);
            usingSlot = 0;
            SetWeaponActivity(usingSlot);
            inventory.ElementAt(FIRSTELEMENT).UseWeapon();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && inventory.Count >= 2)
        {
            _heroAnimatior.SetInteger("weaponID", 2);
            _heroAnimatior.SetBool("changingWeapon", true);
            usingSlot = 1;
            SetWeaponActivity(usingSlot);
            inventory.ElementAt(SECONDELEMENT).UseWeapon();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && inventory.Count == 3)
        {
            _heroAnimatior.SetInteger("weaponID", 3);
            _heroAnimatior.SetBool("changingWeapon", true);
            usingSlot = 2;
            SetWeaponActivity(usingSlot);
            inventory.ElementAt(THIRDELEMENT).UseWeapon();
            return;
        }
    }

    private void RemoveFromInventory()
    {
        if (Input.GetKeyDown(KeyCode.G) && inventory.Any())
        {
            _heroAnimatior.SetInteger("weaponID", 1);
            _heroAnimatior.SetBool("changingWeapon", true);
            inventory.ElementAt(usingSlot).DeafultAmmo();
            inventory.RemoveAt(usingSlot);
            usingSlot--;
            if (usingSlot < 0)
                usingSlot = 0;
        }
    }

    public bool AddToList(IWeapon weapon)
    {
        if (Enum.IsDefined(typeof(_weaponsID), weapon.ID) && inventory.Count <= INVENTORYCAPACITY)
        {
            inventory.Add(weapon);
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<IWeapon> GetInventory()
    {
        return inventory;
    }

    public IWeapon GetUsingWeapon()
    {
        if (inventory.Any())
        {
            return inventory.ElementAt(usingSlot);
        }
        return null;
    }

    public bool IsAdded(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
            if (inventory[i].ID == id)
                return true;
        return false;
    }
}
