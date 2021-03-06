﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Withdrawal : MonoBehaviour {

    Hero hero;
    public Slider withdrawalSLider;
    public float drugWithdrawalMax = 20;
    public bool stopWithdrawalFlag = false;
    float time;


    void Start () {
        hero = GetComponent<Hero>();
        hero.drugWithdrawal = 20;
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if(stopWithdrawalFlag == false)
        {
            drugWithdrawal();
        }
        
      //  deadByWithdrawal();
        withdrawalSLider.value = hero.drugWithdrawal;
        time = Time.time;
    }

    public void drugWithdrawal()
    {
        hero.drugWithdrawal -= (Time.time - time) * 1.2f;
    }

  /*  private void deadByWithdrawal()
    {
        if (hero.drugWithdrawal<=0)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(3);
        }
    }*/

    public void addWithdrawalPoints(float w)
    {
        hero.drugWithdrawal += w;
        if(hero.drugWithdrawal > drugWithdrawalMax)
        {
            hero.drugWithdrawal = drugWithdrawalMax;
        }
    }

    public void stopWithdrawal()
    {
        stopWithdrawalFlag = true;
    }
    public void startWithdrawal()
    {
        stopWithdrawalFlag = false;
    }
}
