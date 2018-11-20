using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoHeraEffect : MonoBehaviour {

    Hero hero;
    DrugsTimer dt;
    int previousStateHero = 20;

    // Use this for initialization
    void Start () {
        Debug.Log("AlcoHera");
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
        previousStateHero = hero.health;
    }
	
	// Update is called once per frame
	void Update () {
		if(dt.vodkaFlag == false || dt.heroineFlag == false)
        {
            Destroy(gameObject);
        }
        effect();
	}

    private void effect()
    {
        if (hero.health < previousStateHero)
        {       
                hero.health += (previousStateHero - hero.health);
        }
    }
}
