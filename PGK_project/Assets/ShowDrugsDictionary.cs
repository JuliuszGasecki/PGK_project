using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDrugsDictionary : MonoBehaviour {

    float actual_time_scale;
    public GameObject container;
    public GameObject HighSpeed;
    public GameObject WhatDoesnt;
    public GameObject HalfDead;
    public GameObject NoAlcoHol;
    public GameObject LordOfTheTime;
    
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        chechMixes();

        if (Input.GetKeyDown(KeyCode.F))
        {
            actual_time_scale = Time.timeScale;
            this.GetComponent<Image>().enabled = true;
            Time.timeScale = 0.0f;
            container.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            Time.timeScale = actual_time_scale;
            this.GetComponent<Image>().enabled = false;
            container.SetActive(false);
        }

       

    }
    private void chechMixes()
    {
        if(GlobalDrugsVariables.alcoHeraOnceTaken)
        {
            Destroy(HalfDead);
        }if(GlobalDrugsVariables.alcoSpeedOnceTaken)
        {
            Destroy(NoAlcoHol);
        }
        if(GlobalDrugsVariables.cocoHeraOnceTaken)
        {
            Destroy(WhatDoesnt);
        }
        if(GlobalDrugsVariables.cocoMaryOnceTaken)
        {
            Destroy(LordOfTheTime);
        }
        if(GlobalDrugsVariables.cocoMDMAOnceTaken)
        {
            Destroy(HighSpeed);
        }
    }
}
