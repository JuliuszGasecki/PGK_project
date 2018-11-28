using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoMaryEffect : MonoBehaviour {

    Hero hero;
    DrugsTimer dt;

    // Use this for initialization
    void Start () {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
        hero.speed += 20;
        Time.timeScale = 0.2f;
    }
	
	// Update is called once per frame
	void Update () {
        if (dt.cocaFlag == false || dt.marihuanaFlag == false)
        {
            if(dt.marihuanaFlag == false)
                Time.timeScale = 1f;
            else
                Time.timeScale = 0.6f;
            hero.speed -= 20;
            Destroy(gameObject);
        }

    }
}
