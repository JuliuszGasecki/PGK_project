using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    private string deadHero = "dead_hero";
    public GameObject deathScene;
    public float temp;
    private Hero hero;
    private SpriteRenderer spriteR;

    void Start()
    {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        spriteR = GameObject.Find("Hero").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (hero.isAlive() == false || hero.drugWithdrawal <= 0 || hero.poisoning > 40)
        {
            spriteR.sprite = Resources.Load<Sprite>(deadHero);
            Pause();
        }
    }

    public void Pause()
    {
        temp = Time.fixedDeltaTime;
        deathScene.SetActive(true);
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
    }
}
