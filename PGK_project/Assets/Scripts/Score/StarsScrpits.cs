using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScrpits : MonoBehaviour {
    public Timer timer;
    public float totalPoints = 0;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject nextLevel;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        calcuulate();
        if(totalPoints < 5)
        {
            //nextLevel.SetActive(false);
        }
        else if(totalPoints >=5 && totalPoints <10)
        {
            star1.SetActive(true);
        }
        else if(totalPoints >= 10 && totalPoints < 15)
        {
            star1.SetActive(true);
            star2.SetActive(true);
        }
        else if (totalPoints >= 15)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }


    }

    public void calcuulate()
    {
        totalPoints = DrugsStat.drugsAlcoValue
            + DrugsStat.drugsCocaValue
            + DrugsStat.drugsExtasyValue
            + (DrugsStat.drugsHeraValue * 3.2f)
            + (DrugsStat.drugsMariValue * 1.5f)
            + DrugsStat.drugsValue
            + (KilledStat.killedValue * 0.1f);
    }
}
