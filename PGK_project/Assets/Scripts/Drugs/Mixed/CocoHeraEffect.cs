using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoHeraEffect : MonoBehaviour {

    Hero hero;
    DrugsTimer dt;
    int previousStateHero = 20;

    // Use this for initialization
    void Start()
    {
        Debug.Log("AlcoHera");
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
        effectPoison();
    }

    // Update is called once per frame
    void Update()
    {
        if (dt.cocaFlag == false || dt.heroineFlag == false)
        {
            hero.speed += 7;
            hero.health += 7;
            Destroy(gameObject);
        }
    }

    private void effectPoison()
    {
        if(Random.Range(1,4) == 2)
        {
            hero.drugWithdrawal += 20;
        }
        hero.speed -= 5;
        hero.health -= 5;

    }
}
