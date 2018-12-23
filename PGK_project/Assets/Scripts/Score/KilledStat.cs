using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KilledStat : MonoBehaviour {

    Text killed;
    public Text combo;
    public Text comboLongest;

    public static int killedValue = 0;
    public static List<float> killedTimeList = new List<float>();

    // Use this for initialization
    void Start () {
        killed = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
        killed.text = "" + killedValue;
        combo.text = ""+DrugsStat.numberOfCombo;
        comboLongest.text = ""+DrugsStat.longestCombo;
    }
}
