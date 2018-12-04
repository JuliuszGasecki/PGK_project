using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    public static float scoreValue = 0;
    Text score;
    Text scoreForPanel;
    void Start () {
        score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreValue = DrugsStat.calculate();
        score.text = "Score: " + scoreValue;
        scoreForPanel.text = ""+scoreValue;

    }
}
