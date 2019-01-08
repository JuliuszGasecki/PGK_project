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
    private bool isPukingAnim;
    float time;
    private float pukeTime;
    float previousSpeed;
    private Animator anim;

    // Use this for initialization
    void Start () {
        hero = GetComponent<Hero>();
        anim = GameObject.Find("Hero").GetComponent<Animator>();
        hero.poisoning = 0;
        time = Time.time;
        isPukingAnim = false;
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
        if(hero.poisoning > poisoningMax / 1.5 && !isPukingAnim)
        {
            pukeTime = Time.time;
            int temp = Random.Range((int)hero.poisoning, (600 - (int)hero.poisoning));
            if(temp == 69)
            {
                previousSpeed = hero.speed;
                //Debug.Log("Porzygusiałem sie mamusiu");
                isPukingAnim = true;
            }
        }
    }

    private void puke()
    {
        if (isPukingAnim)
        {
            if(Time.time - pukeTime < 2)
            {
                hero.poisoning -= 0.1f;
                hero.speed = 1;
                //Debug.Log("Porzygusiałem sie tatusiu");
                anim.SetBool("isPuking", true);
            }
            else
            {
                hero.speed = previousSpeed;
                isPukingAnim = false;
                anim.SetBool("isPuking", false);
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
