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
    public GameObject hangover;
    public GameObject cocoLsd;
    public GameObject weedCigar;
    public bool flag1 = false, flag2 = false, flag3 = false, flag4 = false, flag5 = false, flag6 = false, flag7 = false, flag8 = false;
    // Use this for initialization
    void Start () {
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (dt.extasyFlag && dt.cocaFlag)
        {
            flash.SetActive(true);
            if (!flag1)
            {
                flag1 = true;
            }
        }
        else
        {
            flag1 = false;
            flash.SetActive(false);
        }

        if (dt.extasyFlag || dt.cocaFlag)
        {
            noAlcohol.SetActive(true);
            if (!flag2)
            {
                flag2 = true;
                DrugsStat.drugsComboNoAlcohol++;
            }
        }
        else
        {
            flag2 = false;
            noAlcohol.SetActive(false);
        }

        if (dt.vodkaFlag && dt.heroineFlag)
        {
            halfDead.SetActive(true);
            if (!flag3)
            {
                flag3 = true;
                DrugsStat.drugsComboHalfDead++;
            }
        }
        else
        {
            flag3 = false;
            halfDead.SetActive(false);
        }

        if (dt.cocaFlag && dt.heroineFlag)
        {
            whatDoesntKillYou.SetActive(true);
            if (!flag4)
            {
                flag4 = true;
                DrugsStat.drugsCombowhatDoesntKillYou++;

            }
        }
        else
        {
            flag4 = false;
            whatDoesntKillYou.SetActive(false);
        }

        if (dt.marihuanaFlag && dt.cocaFlag)
        {
            lordOftheTime.SetActive(true);
            if (!flag5)
            {
                flag5 = true;
                DrugsStat.drugsComboLordOftheTime++;
            }
        }
        else
        {
            lordOftheTime.SetActive(false);
            flag5 = false;
        }
        if (dt.marihuanaFlag && dt.cigaretteFlag)
        {
            weedCigar.SetActive(true);
            if (!flag6)
            {
                flag6 = true;
                DrugsStat.drugsComboSmokeGrenade++;
            }
        }
        else
        {
            weedCigar.SetActive(false);
            flag6 = false;
        }
        if (dt.cocaFlag && dt.lsdFlag)
        {
            cocoLsd.SetActive(true);
            if (!flag7)
            {
                flag7 = true;
                DrugsStat.drugsComboWTF++;
            }
        }
        else
        {
            cocoLsd.SetActive(false);
            flag7 = false;
        }
        if (GameObject.Find("Hero").GetComponent<Hero>().hangover)
        {
            hangover.SetActive(true);
            if (!flag8)
            {
                flag8 = true;
                DrugsStat.drugsCombHangover++;
            }
        }
        else
        {
            hangover.SetActive(false);
            flag8 = false;
        }
    }
}
