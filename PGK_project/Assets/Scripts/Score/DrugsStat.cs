using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugsStat : MonoBehaviour {

    public static int drugsValue = 0;
    public static int drugsHeraValue = 0;
    public static int drugsCocaValue = 0;
    public static int drugsMariValue = 0;
    public static int drugsAlcoValue = 0;
    public static int drugsExtasyValue = 0;
    Text drugs; 
	void Start () {
        drugs = GetComponent<Text>();
	}
	

	void Update () {
        drugs.text = "" + drugsValue + "\n\n" + drugsHeraValue + "\n" + drugsCocaValue+ "\n" + drugsMariValue+ "\n" + drugsAlcoValue+"\n"+ drugsExtasyValue;
	}
}
