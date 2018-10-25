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

    // Use this for initialization
    void Start () {
        hero = GetComponent<Hero>();
        hero.poisoning = 0;
    }
	
	// Update is called once per frame
	void Update () {
        poisoningEffect();
        Debug.Log(hero.poisoning);
        poisonDeath();
        poisoninglSLider.value = hero.poisoning;
        
    }

    public void poisoningEffect()
    {
        if(hero.poisoning > 0)
        hero.poisoning -= Time.fixedDeltaTime;
    }

    private void poisonDeath()
    {
        if (hero.poisoning > poisoningMax)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(3);
        }
    }

}
