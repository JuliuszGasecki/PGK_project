using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangover : MonoBehaviour {

    private float time;
    private Hero hero;
    private DrugsTimer drugsTimer;

    private int maxHp;
    private float speed;

	// Use this for initialization
	void Start () {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        drugsTimer = GameObject.Find("Hero").GetComponent<DrugsTimer>();
        time = Time.time;
        maxHp = hero.maxHeath;
        speed = hero.speed;
	}
	
	// Update is called once per frame
	void Update () {

        if (!drugsTimer.onDrugs)
        {
            GameObject.Find("NarcoManager").GetComponent<NarcoManager>().hangoverStart();
            hero.maxHeath = maxHp - 5;
            hero.speed = speed - 5;
        }
        else
        {
            hero.maxHeath = maxHp;
            hero.speed = speed;
            Destroy(gameObject);
        }
		
	}
}
