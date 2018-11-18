using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholEffect : MonoBehaviour {
    Hero hero;
    DrugsTimer dt;
    Camera cam;
    private float angle = 0;
    int previousStateHero = 20;


    private void Start()
    {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        previousStateHero = hero.health;
        DrugsStat.drugsAlcoValue++;
    }

    // Update is called once per frame
    void Update () {
        cam.GetComponent<CameraController>().MoveSpeed = 1;
        if (!dt.vodkaFlag)
        {
            lifeEffect();
            Destroy(gameObject);
        }

    }

    void lifeEffect()
    {
        cam.GetComponent<CameraController>().MoveSpeed = 100;
        hero.health -=
            20 + (hero.health - previousStateHero);
    }
    
}
