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
    public bool flag1 = false, flag2 = false, flag3 = false, flag4 = false, flag5 = false;
    // Use this for initialization
    void Start () {
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(dt.extasyFlag && dt.cocaFlag)
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
    }
}
