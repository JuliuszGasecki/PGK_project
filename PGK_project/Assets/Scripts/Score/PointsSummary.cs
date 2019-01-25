using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsSummary : MonoBehaviour {

    public Text text1_narco_1;
    public Text text2_narco_1_bonus;
    public Text text3_narco_2;
    public Text text4_narco_2_bonus;
    public Text text5_time;
    public Text text6_time_bonus;
    double bonus;
    public float Hera { get; set; }
    public float Coca { get; set; }
    public float Mari { get; set; }
    public float Alco { get; set; }
    public float Extasy { get; set; }
    public float LSD { get; set; }
    public float Mocarz { get; set; }
    public float Meth { get; set; }
    public float Fajki { get; set; }
    public int DrugsValue { get; set; }
    public float ComboFlash { get; set; }
    public float CombowhatDoesntKillYou { get; set; }
    public float ComboHalfDead { get; set; }
    public float ComboLordOftheTime { get; set; }
    public float ComboNoAlcohol { get; set; }
    public float ComboSmokeGrenade { get; set; }
    public float ComboWTF { get; set; }
    public float ComboHangover { get; set; }

    void Start()
    {
        SetData();
        text1_narco_1.text = "Amount\n\n\t" + DrugsStat.drugsHeraValue + "\n\t" + DrugsStat.drugsCocaValue + "\n\t" +
                                DrugsStat.drugsMariValue + "\n\t" + DrugsStat.drugsAlcoValue + "\n\t" + DrugsStat.drugsExtasyValue + "\n\t" +
                                DrugsStat.drugsLSDValue + "\n\t" + DrugsStat.drugsMocarzValue + "\n\t" + DrugsStat.drugsMethValue + "\n\t" +
                                DrugsStat.drugsFajkiValue + "\n\n\t" + DrugsStat.drugsValue;

        text2_narco_1_bonus.text = "After Bonus\n\n\t" + Hera + "\n\t" + Coca + "\n\t" + Mari + "\n\t" + Alco + "\n\t" + Extasy + "\n\t" +
                                LSD + "\n\t" + Mocarz + "\n\t" + Meth + "\n\t" + Fajki;

        text3_narco_2.text = "Amount\n\n\t" + DrugsStat.drugsComboFlash + "\n\t" + DrugsStat.drugsCombowhatDoesntKillYou + "\n\t" +
                                DrugsStat.drugsComboHalfDead + "\n\t" + DrugsStat.drugsComboLordOftheTime + "\n\t" + DrugsStat.drugsComboNoAlcohol + "\n\t" +
                                DrugsStat.drugsComboSmokeGrenade + "\n\t" + DrugsStat.drugsComboWTF + "\n\t" + DrugsStat.drugsCombHangover;

        text4_narco_2_bonus.text = "After Bonus\n\n\t" + ComboFlash + "\n\t" + CombowhatDoesntKillYou + "\n\t" + ComboHalfDead + "\n\t" +
                                ComboLordOftheTime + "\n\t" + ComboNoAlcohol + "\n\t" + ComboSmokeGrenade + "\n\t" + ComboWTF + "\n\t" + ComboHangover;

        text5_time.text = "" + Math.Round(Timer.time, 2);

        bonus = Math.Round(DrugsStat.wspolczynnikRundy / Timer.time, 2);
        text6_time_bonus.text = "" + bonus;
    }
    void Update()
    {
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
        Meth = DrugsStat.drugsMethValue;
        Fajki = DrugsStat.drugsFajkiValue;
        DrugsValue = DrugsStat.drugsValue;
        ComboFlash = (float)Math.Pow(2.3, DrugsStat.drugsComboFlash) - 1;
        CombowhatDoesntKillYou = DrugsStat.drugsCombowhatDoesntKillYou * 3.4f;
        ComboHalfDead = DrugsStat.drugsComboHalfDead * 2.0f;
        ComboLordOftheTime = DrugsStat.drugsComboLordOftheTime * 8.7f;
        ComboNoAlcohol = DrugsStat.drugsComboNoAlcohol * 2.0f;
        ComboWTF = DrugsStat.drugsComboWTF;
        ComboSmokeGrenade = DrugsStat.drugsComboSmokeGrenade;
        ComboHangover = DrugsStat.drugsCombHangover * 5;
    }
}
