using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocaMDMAAlcoholEffect : MonoBehaviour {

    Hero hero;
    DrugsTimer dt;
    float timeBeforeDestroy;
    float time;
    // Use this for initialization
    void Start () {
        Debug.Log("AlcoSpeed");
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
        dt.removeNarcotic("vodka");
        var sound = this.GetComponent<AudioSource>();
        timeBeforeDestroy = sound.clip.length;
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeDestroy -= (Time.time - time);
        if (timeBeforeDestroy <= 0f)
        {
            Destroy(this.gameObject);
        }
        time = Time.time;
    }
}
