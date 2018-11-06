using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
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
       // inventory.Add(GameObject.Find(M4));
    }
	
	// Update is called once per frame
	void Update () {
		
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
