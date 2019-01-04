using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySpecialWeaponIcon : MonoBehaviour {

    private Inventory weapon;
    private Image image;
    private Sprite sprite;

    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    weapon = GameObject.Find("Inventory").GetComponent<Inventory>();
	    if (weapon.GetUsingSpecialWeapon() == null)
	    {
	        image.enabled = false;
	    }
	    else if (Time.timeScale == 0f)          //usun icon w summaryPanel
	    {
	        image.enabled = false;
	    }
	    else
	    {
	        image.enabled = true;
	        image.type = Image.Type.Filled;
	        image.fillMethod = Image.FillMethod.Radial360;
	        image.sprite = Resources.Load<Sprite>("Weapons/" + weapon.GetUsingSpecialWeapon().Name);
	    }

    }
}
