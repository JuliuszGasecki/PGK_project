using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWeaponIcon : MonoBehaviour
{
    private string weapon;
    private Image image;

    private Sprite sprite;
	// Use this for initialization
	void Start ()
	{
	    image = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
	    weapon = GameObject.Find("Hero").GetComponent<Inventory>().GetUsingWeapon().Name;
	    if (weapon == null)
	    {
	        image.enabled = false;
	    }
	    else
	    {
            image.enabled = true;
	        image.sprite = Resources.Load<Sprite>(weapon);
	    }
	}
}
