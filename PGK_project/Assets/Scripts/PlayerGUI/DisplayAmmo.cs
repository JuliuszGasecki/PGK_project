using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAmmo : MonoBehaviour {

    private Text text_ammo;

    private IWeapon weapon;
    // Use this for initialization
    void Start () {
        text_ammo = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update ()
	{
	    weapon = GameObject.Find("Hero").GetComponent<Inventory>().GetUsingWeapon();
	    if (weapon == null)
	    {
	        text_ammo.text = "EMPTY";
	    }
	    else
	    {
	        text_ammo.text = weapon.DisplayToTextAmmo();
        }
	}


}
