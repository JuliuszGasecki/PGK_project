using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoLsdEffect : MonoBehaviour {

    Hero hero;
    DrugsTimer dt;
    private float time;
	// Use this for initialization
	void Start () {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
        Time.timeScale = 1.4f;
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (dt.cocaFlag == false || dt.lsdFlag == false)
        {
            Time.timeScale = 1.0f;
            Destroy(gameObject);
        }
    }
}
