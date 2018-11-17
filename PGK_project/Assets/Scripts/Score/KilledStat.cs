using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KilledStat : MonoBehaviour {

    Text killed;
    public static int killedValue = 0;

    // Use this for initialization
    void Start () {
        killed = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        killed.text = "" + killedValue;

    }
}
