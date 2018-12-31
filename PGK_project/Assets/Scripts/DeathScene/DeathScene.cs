using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    private string deadHero = "dead_hero";
    public GameObject deathScene;
    private Hero hero;
    private SpriteRenderer spriteR;
    private Animator anim;

    void Start()
    {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        spriteR = GameObject.Find("Hero").GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (hero.isAlive() == false || hero.drugWithdrawal <= 0 || hero.poisoning > 40)
        {
            anim.enabled = false;
            spriteR.sprite = Resources.Load<Sprite>(deadHero);
            transform.localScale = new Vector3(0.22f, 0.22f, 0.22f);
            GameObject.Find("Inventory").GetComponent<Inventory>().GetUsingWeapon().CanUse = false;
            Pause();
        }
    }

    public void Pause()
    {
        deathScene.SetActive(true);
        Time.timeScale = 0f;
       // Time.fixedDeltaTime = 0f;
    }
}
