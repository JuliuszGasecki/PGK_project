using System;
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
    DrugsStat ds;
    bool dox = true;
    void Start () {
        ds = new DrugsStat();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (dox)
        {
            totalPoints = DrugsStat.calculate();
            totalPoints = totalPoints * DrugsStat.wspolczynnikRundy / Timer.time;           //wspolczynnik rundy
        }
        if(EndPoint.done == true)
        {
            EndPoint.done = false;
            dox = false;
            totalPoints = ds.getComboMultiplier(ds.getKilledCombo(), totalPoints);
            DrugsStat.totalPointsLevel = totalPoints;
            SetCountOfReachedStars();
            SetActiveStars();
            SaveLevel();
        }
        scoreForPanel.text = "        " + (int) totalPoints;

    }
    public void SaveLevel()
    {
        LevelsStatistic.Level new_level = new LevelsStatistic.Level
            (DrugsStat.level, DrugsStat.totalPointsLevel, DrugsStat.reachedStars, DrugsStat.completed, 3,DrugsStat.numberOfCombo,DrugsStat.longestCombo);
        LevelsStatistic.level_repo.Add(new_level);
    }

    public void SetCountOfReachedStars()
    {
        if (totalPoints < 5)
        {
            DrugsStat.reachedStars = 0;
            DrugsStat.completed = false;
        }
        else if (totalPoints >= 5 && totalPoints < 10)
        {
            DrugsStat.reachedStars = 1;
            DrugsStat.completed = true;
        }
        else if (totalPoints >= 10 && totalPoints < 15)
        {
            DrugsStat.reachedStars = 2;
            DrugsStat.completed = true;
        }
        else if (totalPoints >= 15)
        {
            DrugsStat.reachedStars = 3;
            DrugsStat.completed = true;
        }
    }

    public void SetActiveStars()
    {
        if(DrugsStat.reachedStars == 0)
        {
            nextLevel.SetActive(false);
            tryAgainText.SetActive(true);
        }
        else if (DrugsStat.reachedStars == 1)
        {
            star1.SetActive(true);
            nextLevel.SetActive(true);
            tryAgainText.SetActive(false);
        }
        else if (DrugsStat.reachedStars == 2)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            nextLevel.SetActive(true);
            tryAgainText.SetActive(false);
        }
        else if (DrugsStat.reachedStars == 3)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            nextLevel.SetActive(true);
            tryAgainText.SetActive(false);
        }
    }
}
