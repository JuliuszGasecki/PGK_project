﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Withdrawal : MonoBehaviour {

    public Hero hero;
    public Slider withdrawalSLider;
    public float drugWithdrawalMax = 20;
    public bool stopWithdrawalFlag = false;


    void Start () {
        hero.drugWithdrawal = 10;
	}
	
	// Update is called once per frame
	void Update () {
        if(stopWithdrawalFlag == false)
        {
            drugWithdrawal();
        }
        
        deadByWithdrawal();
        withdrawalSLider.value = hero.drugWithdrawal;
    }

    public void drugWithdrawal()
    {
        hero.drugWithdrawal -= Time.fixedDeltaTime;
    }

    private void deadByWithdrawal()
    {
        if (hero.drugWithdrawal<=0)
        {
            hero.health = 0;
        }
    }

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
