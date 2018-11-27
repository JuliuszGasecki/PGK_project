using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixImagemanager : MonoBehaviour {

    DrugsTimer dt;
    public GameObject flash;
    public GameObject whatDoesntKillYou;
    public GameObject halfDead;
    public GameObject lordOftheTime;
    public GameObject noAlcohol;
	// Use this for initialization
	void Start () {
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(dt.extasyFlag && dt.cocaFlag)
        {
            flash.SetActive(true);
        }
        else
        {
            flash.SetActive(false);
        }

        if (dt.extasyFlag || dt.cocaFlag)
        {
            noAlcohol.SetActive(true);
        }
        else
        {
            noAlcohol.SetActive(false);
        }

        if (dt.vodkaFlag && dt.heroineFlag)
        {
            halfDead.SetActive(true);
        }
        else
        {
            halfDead.SetActive(false);
        }

        if (dt.cocaFlag && dt.heroineFlag)
        {
            whatDoesntKillYou.SetActive(true);
        }
        else
        {
            whatDoesntKillYou.SetActive(false);
        }

        if (dt.marihuanaFlag && dt.cocaFlag)
        {
            lordOftheTime.SetActive(true);
        }
        else
        {
            lordOftheTime.SetActive(false);
        }



    }
}
