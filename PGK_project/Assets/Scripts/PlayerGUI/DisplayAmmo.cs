using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAmmo : MonoBehaviour {

    private Text text_ammo;

    private Inventory weapon;
    // Use this for initialization
    void Start () {
        text_ammo = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update ()
	{
	    weapon = GameObject.Find("Inventory").GetComponent<Inventory>();
	    if (weapon.GetUsingWeapon() == null || Time.timeScale == 0f || weapon.VMode || weapon.VModeUser)
	    {
	        text_ammo.text = "";
	    }
	    else
	    {
	        text_ammo.text = weapon.GetUsingWeapon().DisplayToTextAmmo();
        }
	}


}
