using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoMdmaEffect : MonoBehaviour {

    Hero hero;
    DrugsTimer dt;
    HeroController hc;
    // Use this for initialization
    void Start () {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
        hc = hero.GetComponent < HeroController > ();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            hc.flash();
        }
	}
}
