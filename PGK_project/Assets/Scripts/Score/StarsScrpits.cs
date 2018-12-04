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
    public GameObject tryAgainText;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("PUNKTYYYYYYYYYYYY:              " + totalPoints);
        totalPoints = DrugsStat.calculate();
        if(totalPoints < 5)
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
