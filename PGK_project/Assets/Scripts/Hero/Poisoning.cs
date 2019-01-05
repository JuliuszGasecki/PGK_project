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
    private bool isPuking;
    float time;
    private float pukeTime;
    float previousSpeed;

    // Use this for initialization
    void Start () {
        hero = GetComponent<Hero>();
        hero.poisoning = 0;
        time = Time.time;
        isPuking = false;
    }
	
	// Update is called once per frame
	void Update () {
        poisoningEffect();
        //poisonDeath();
        poisoninglSLider.value = hero.poisoning;
        time = Time.time;
        checkPuke();
        puke();
    }

    public void poisoningEffect()
    {
        if(hero.poisoning > 0)
        hero.poisoning -= (Time.time - time) * 0.7f;
    }

    private void checkPuke()
    {
        if(hero.poisoning > poisoningMax / 1.5 && !isPuking)
        {
            pukeTime = Time.time;
            int temp = Random.Range((int)hero.poisoning, (600 - (int)hero.poisoning));
            if(temp == 69)
            {
                previousSpeed = hero.speed;
                Debug.Log("Porzygusiałem sie mamusiu");
                isPuking = true;
            }
        }
    }

    private void puke()
    {
        if (isPuking)
        {
            if(Time.time - pukeTime < 2)
            {
                hero.poisoning -= 0.1f;
                hero.speed = 1;
                Debug.Log("Porzygusiałem sie tatusiu");
            }
            else
            {
                hero.speed = previousSpeed;
                isPuking = false;
            }
            
        }
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
