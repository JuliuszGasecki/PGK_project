using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffEnterance : MonoBehaviour {

    public static bool turnedOn = false;
    public GameObject baby;

	// Use this for initialization
	void Start () {
        if (turnedOn)
        {
            GameObject.Find("PEGI18").SetActive(false);
            baby.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
