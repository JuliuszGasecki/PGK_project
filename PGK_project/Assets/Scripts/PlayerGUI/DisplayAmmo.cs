﻿using UnityEngine;
using UnityEngine.UI;

public class DisplayAmmo : MonoBehaviour {

    private Text text_ammo;
    // Use this for initialization
    void Start () {
        text_ammo = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
	{

	    text_ammo.text = GameObject.Find("Hero").GetComponent<M4>().ammoInMagazine.ToString() + "/" +
	                     GameObject.Find("Hero").GetComponent<M4>().ammo.ToString();
	}


}
