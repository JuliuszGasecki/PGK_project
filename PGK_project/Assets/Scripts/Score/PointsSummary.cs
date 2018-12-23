using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsSummary : MonoBehaviour {

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5_time_bonus;
    double bonus;
    public float Hera { get; set; }
    public float Coca { get; set; }
    public float Mari { get; set; }
    public float Alco { get; set; }
    public float Extasy { get; set; }
    public float LSD { get; set; }
    public float Mocarz { get; set; }
    public int DrugsValue { get; set; }
    public float ComboFlash { get; set; }
    public float CombowhatDoesntKillYou { get; set; }
    public float ComboHalfDead { get; set; }
    public float ComboLordOftheTime { get; set; }
    public float ComboNoAlcohol { get; set; }

    void Start () {
        SetData();
        text1.text = "Amount\n\t" + DrugsStat.drugsHeraValue + "\n\t" + DrugsStat.drugsCocaValue + "\n\t" +
                        DrugsStat.drugsMariValue + "\n\t" + DrugsStat.drugsAlcoValue + "\n\t" + DrugsStat.drugsExtasyValue + "\n\t" +
                        DrugsStat.drugsLSDValue + "\n\t" + DrugsStat.drugsMocarzValue + "\n\n\t" + DrugsStat.drugsValue;
        text2.text = "After Bonus\n\t" + Hera + "\n\t" + Coca + "\n\t" + Mari + "\n\t" + Alco + "\n\t" + Extasy + "\n\t" + LSD + "\n\t" + Mocarz;
        text3.text = "Amount\n\n\t" + DrugsStat.drugsComboFlash + "\n\t" + DrugsStat.drugsCombowhatDoesntKillYou + "\n\t" + DrugsStat.drugsComboHalfDead + "\n\t" +
                    DrugsStat.drugsComboLordOftheTime + "\n\t" + DrugsStat.drugsComboNoAlcohol;
        text4.text = "After Bonus\n\n\t" + ComboFlash + "\n\t" + CombowhatDoesntKillYou + "\n\t" + ComboHalfDead + "\n\t" + ComboLordOftheTime + "\n\t" + ComboNoAlcohol;
        
        text5_time_bonus.text = "" + bonus;
    }
	void Update ()
    {
        text5_time_bonus.text = "" + bonus;
        bonus = Math.Round(DrugsStat.wspolczynnikRundy / Timer.time,2);
    }

    public void SetData()
    {
        Hera = DrugsStat.drugsHeraValue * 3.2f;
        Coca = (float)Math.Pow(1.3, DrugsStat.drugsCocaValue) - 1;
        Mari = DrugsStat.drugsMariValue * 1.5f;
        Alco = DrugsStat.drugsAlcoValue;
        Extasy = DrugsStat.drugsExtasyValue;
        LSD = DrugsStat.drugsLSDValue;
        Mocarz = DrugsStat.drugsMocarzValue * 1.5f;
        DrugsValue = DrugsStat.drugsValue;
        ComboFlash = (float)Math.Pow(2.3, DrugsStat.drugsComboFlash) - 1;
        CombowhatDoesntKillYou = DrugsStat.drugsCombowhatDoesntKillYou * 3.4f;
        ComboHalfDead = DrugsStat.drugsComboHalfDead * 2.0f;
        ComboLordOftheTime = DrugsStat.drugsComboLordOftheTime * 8.7f;
        ComboNoAlcohol = DrugsStat.drugsComboNoAlcohol * 2.0f;
    }






}
