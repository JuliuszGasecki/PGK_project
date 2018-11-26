using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWeaponIcon1 : MonoBehaviour {

    private Inventory weapon;
    private Image image;
    private Sprite sprite;
    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
	    weapon = GameObject.Find("Inventory").GetComponent<Inventory>();
        if (weapon.IsSecondWeapon() && weapon.SecondWeapon != null)
	    {
	        image.enabled = true;
	        image.type = Image.Type.Filled;
	        image.fillMethod = Image.FillMethod.Radial360;
	        image.sprite = Resources.Load<Sprite>("Weapons/" + weapon.SecondWeapon.Name);
	    }
	     else if (!weapon.IsSecondWeapon())
         {
             image.enabled = false;
         }
    }
}
