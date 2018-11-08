using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholEffect : MonoBehaviour {
    Hero hero;
    DrugsTimer dt;
    int previousStateHero = 20;


    private void Start()
    {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
        previousStateHero = hero.health;
    }

    // Update is called once per frame
    void Update () {
        if(!dt.vodkaFlag)
        {
            alcoholEffect();
            Destroy(gameObject);
        }
		
	}

    void alcoholEffect()
    {
        hero.health -= this.gameObject.GetComponent<DrugTemplate>().lifeBoost + (hero.health - previousStateHero);
    }
}
