﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsScrpits : MonoBehaviour {
    public float totalPoints = 0;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject nextLevel;
    public GameObject tryAgainText;
    public Text scoreForPanel;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log("PUNKTYYYYYYYYYYYY:              " + totalPoints);
        totalPoints = DrugsStat.calculate();
        totalPoints = totalPoints * DrugsStat.wspolczynnikRundy / Timer.time;           //wspolczynnik rundy
        scoreForPanel.text = "        " + (int)totalPoints;
        if (totalPoints < 5)
        {  
            nextLevel.SetActive(false);
            tryAgainText.SetActive(true);
        }
        else if(totalPoints >=5 && totalPoints <10)
        {
            star1.SetActive(true);
            nextLevel.SetActive(true);
            tryAgainText.SetActive(false);
        }
        else if(totalPoints >= 10 && totalPoints < 15)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            nextLevel.SetActive(true);
            tryAgainText.SetActive(false);
        }
        else if (totalPoints >= 15)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            nextLevel.SetActive(true);
            tryAgainText.SetActive(false);
        }
    }
}