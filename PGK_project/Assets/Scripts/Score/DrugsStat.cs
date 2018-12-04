using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugsStat : MonoBehaviour {

    public static int killed = 0;
    public static int drugsValue = 0;
    public static int drugsHeraValue = 0;
    public static int drugsCocaValue = 0;
    public static int drugsMariValue = 0;
    public static int drugsAlcoValue = 0;
    public static int drugsExtasyValue = 0;
    public static int drugsComboFlash = 0;
    public static int drugsCombowhatDoesntKillYou = 0;
    public static int drugsComboHalfDead = 0;
    public static int drugsComboLordOftheTime = 0; 
    public static int drugsComboNoAlcohol = 0;

    public static int level = 0;

    public static float totalPoints = 0;
    Text drugs; 
	void Start () {
        drugs = GetComponent<Text>();
	}
	

	void Update () {
        drugs.text = "" + drugsValue + "\n\n" + drugsHeraValue + "\n" + drugsCocaValue+ "\n" + drugsMariValue+ "\n" + drugsAlcoValue+"\n"+ drugsExtasyValue;
        killed = KilledStat.killedValue;
    }

    public static void AllStatsReset()
    {
        drugsValue = 0;
        drugsHeraValue = 0;
        drugsCocaValue = 0;
        drugsMariValue = 0;
        drugsAlcoValue = 0;
        drugsExtasyValue = 0;
        drugsComboFlash = 0;
        drugsCombowhatDoesntKillYou = 0;
        drugsComboHalfDead = 0;
        drugsComboLordOftheTime = 0;
        drugsComboNoAlcohol = 0;
        KilledStat.killedValue = 0;
        ScoreCounter.scoreValue = 0;
        totalPoints = 0;
    }

    public static float calculate()
    {
        killed = KilledStat.killedValue;
        totalPoints = drugsAlcoValue
         + (float)Math.Pow(1.3, drugsCocaValue)-1
        + drugsExtasyValue
        + (drugsHeraValue * 3.2f)
        + (drugsMariValue * 1.5f)
        + drugsValue
        + (killed * 2.7f)
        + drugsComboFlash
        + (drugsCombowhatDoesntKillYou * 3.4f)
        - (drugsComboHalfDead * 2.0f)
        + (drugsComboLordOftheTime * 5.1f)
        + (drugsComboNoAlcohol);

        return totalPoints;
    }
}
