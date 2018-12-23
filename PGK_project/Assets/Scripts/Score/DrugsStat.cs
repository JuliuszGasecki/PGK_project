using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DrugsStat : MonoBehaviour {

    public static int killed = 0;
    public static int drugsValue = 0;
    public static int drugsHeraValue = 0;
    public static int drugsCocaValue = 0;
    public static int drugsMariValue = 0;
    public static int drugsAlcoValue = 0;
    public static int drugsExtasyValue = 0;
    public static int drugsLSDValue = 0;
    public static int drugsMocarzValue = 0;
    public static int drugsComboFlash = 0;
    public static int drugsCombowhatDoesntKillYou = 0;
    public static int drugsComboHalfDead = 0;
    public static int drugsComboLordOftheTime = 0;
    public static int drugsComboNoAlcohol = 0;

    public static int level = 0;
    public static int wspolczynnikRundy = 40;
    public static float totalPoints = 0;
    public static float totalPointsLevel = 0;
    public static int reachedStars = 0;
    public static bool completed = false;
    public static int numberOfCombo = 0;
    public static int longestCombo = 0;

    public Text drugs1;
    public Text drugs2;

    public static Dictionary<int, int> comboKilled = new Dictionary<int, int>();
    public static List<int> openedLvls = new List<int>();

    void Start()
    {
    }


    void Update() {
        drugs1.text = "" + drugsValue + "\n\n" + drugsHeraValue + "\n" + drugsCocaValue + "\n" + drugsMariValue + "\n" + drugsAlcoValue;
        drugs2.text = "\n\n" + drugsExtasyValue + "\n" + drugsLSDValue + "\n" + drugsMocarzValue;
        killed = KilledStat.killedValue;
        foreach (var item in openedLvls)
        {
            Debug.Log("OPENED: " + item.ToString());
        }
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
        drugsLSDValue = 0;
        drugsMocarzValue = 0;
        drugsCombowhatDoesntKillYou = 0;
        drugsComboHalfDead = 0;
        drugsComboLordOftheTime = 0;
        drugsComboNoAlcohol = 0;
        KilledStat.killedValue = 0;
        ScoreCounter.scoreValue = 0;
        totalPoints = 0;
        totalPointsLevel = 0;
        comboKilled.Clear();
        KilledStat.killedTimeList.Clear();
    }

    public static float calculate()
    {

        killed = KilledStat.killedValue;
        totalPoints = drugsAlcoValue
         + (float)Math.Pow(1.3, drugsCocaValue) - 1
        + drugsExtasyValue
        + (drugsHeraValue * 3.2f)
        + (drugsMariValue * 1.5f)
        + drugsValue
        + (killed * 2.7f)
         + (float)Math.Pow(2.3, drugsComboFlash) - 1
        + (drugsCombowhatDoesntKillYou * 3.4f)
        - (drugsComboHalfDead * 2.0f)
        + (drugsComboLordOftheTime * 8.7f)
        + (drugsComboNoAlcohol * 2.0f)
        + drugsLSDValue
        + (drugsMocarzValue * (1.5f));

        Math.Round(totalPoints, 2);

        return totalPoints;
    }

    public Dictionary<int, int> getKilledCombo()
    {
        int numberOfCombo = 0;
        int result = 1;
        if (KilledStat.killedTimeList.Count == 0)
        {
            comboKilled.Add(0, 0);
            return comboKilled;
        }
        else
        {

            float time1 = KilledStat.killedTimeList[0];
            foreach (var item in KilledStat.killedTimeList)
            {
                if(item - time1 != 0 && item - time1 <=5)
                {
                    result++;
                }
                else
                {
                    if(result != 1)
                    {
                        numberOfCombo++;
                        comboKilled.Add(numberOfCombo, result);
                        result = 1;
                    }
                    time1 = item;
                }
            }
            numberOfCombo++;
            comboKilled.Add(numberOfCombo, result);
            return comboKilled;
        }
    }

    public int getPointsBonusCombo(Dictionary<int, int> combo)
    {
        numberOfCombo = combo.Keys.Max();
        return numberOfCombo * 5;
    }
    public float getComboMultiplier(Dictionary<int, int> combo, float result)
    {
        foreach (var item in combo.Keys)
        {
            if(combo[item] != 0)
                result *= combo[item] * 0.65f;
        }
        longestCombo = combo.Values.Max();
        return result + this.getPointsBonusCombo(combo);
    }

}
