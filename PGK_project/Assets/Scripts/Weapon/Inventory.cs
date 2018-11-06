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
    private int usingSlot = 0;
    private enum _weaponsID
    {
        DEAGLE,
        M4,
        MP5,
        SPAS12,
        KNIFE
    };

    private List<IWeapon> inventory;
	// Use this for initialization
	void Start () {
	    inventory = new List<IWeapon>();
        inventory.Add(this.gameObject.GetComponent<M4>());
        inventory.ElementAt(FIRSTELEMENT).CanUse = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    UseWeapon();
	    RemoveFromInventory();
	}

    private void SetWeaponActivity(int avoid)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (i == avoid) inventory.ElementAt(i).CanUse = true;
                inventory.ElementAt(i).CanUse = false;
        }
    }

    private void UseWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) && inventory.Count >= 1)
        {
            usingSlot = 0;
            SetWeaponActivity(usingSlot);
            inventory.ElementAt(FIRSTELEMENT).UseWeapon();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && inventory.Count >= 2)
        {
            usingSlot = 1;
            SetWeaponActivity(usingSlot);
            inventory.ElementAt(SECONDELEMENT).UseWeapon();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && inventory.Count == 3)
        {
            usingSlot = 2;
            SetWeaponActivity(usingSlot);
            inventory.ElementAt(THIRDELEMENT).UseWeapon();
            return;
        }
    }

    private void RemoveFromInventory()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
           inventory.RemoveAt(usingSlot);
        }
    }

    public bool AddToList(IWeapon weapon)
    {
        if (Enum.IsDefined(typeof(_weaponsID), weapon.ID))
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
}
