using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroina : MonoBehaviour {

    Hero hero;
    DrugsTimer dt;
    int previousStateHero = 20;

    private void Start()
    {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
        previousStateHero = hero.health;

        DrugsStat.drugsValue++;
        DrugsStat.drugsHeraValue++;
    }
    private void Update()
    {
        if (dt.heroineFlag)
        {
            heroieEffect();
        }
        else
        {
            Debug.Log("Usunięto efekt");
            Destroy(gameObject);
        }
            
    }

    private void heroieEffect()
    {
        if(hero.health < previousStateHero)
        {
            int random = Random.Range(1, 3);
            Debug.Log("lol" + random);
            if(random%2 == 0)
            {
                hero.health += (previousStateHero - hero.health);
            }
        }
        previousStateHero = hero.health;
    }

}
