using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Poisoning : MonoBehaviour {

    Hero hero;
    public Slider poisoninglSLider;
    public float poisoningMax;
    public bool poisoningFlag = false;
    float time;

    // Use this for initialization
    void Start () {
        hero = GetComponent<Hero>();
        hero.poisoning = 0;
        time = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        poisoningEffect();
        //poisonDeath();
        poisoninglSLider.value = hero.poisoning;
        time = Time.time;
    }

    public void poisoningEffect()
    {
        if(hero.poisoning > 0)
        hero.poisoning -= (Time.time - time) * 1.2f;
    }

    /*private void poisonDeath()
    {
        if (hero.poisoning > poisoningMax)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(4);
        }
    }*/

}
