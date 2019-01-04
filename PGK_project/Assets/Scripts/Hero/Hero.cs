using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHeath;
    public int health;
    public float speed;
    public float poisoning;
    public float drugWithdrawal;
    public float attack;
    public Transform spawnPoint;
    private float wojtek; //speed after what doesnt kill u

   /* private int tempHealth;

    private float tempSpeed;

    private float tempPoisoning;

    private float tempDrugWithdrawal;

    private float tempAttack;*/
    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 1f;
        this.transform.position = spawnPoint.position;
       /* tempHealth = health;
        tempSpeed = speed;
        tempPoisoning = poisoning;
        tempDrugWithdrawal = drugWithdrawal;
        tempAttack = attack;*/
        wojtek = speed;
    }

	// Update is called once per frame
	void Update ()
	{
        if (health > maxHeath)
            health = maxHeath;
        healthSlider.value = health;
        // respawn();
        czyWojtek();
        speedWithoutDrugs();
    }

    private void czyWojtek()
    {
        if(GlobalDrugsVariables.cocoHeraOnceTaken)
        {
            wojtek = 10;
        }
    }

    private void speedWithoutDrugs()
    {
        if(!gameObject.GetComponent<DrugsTimer>().onDrugs)
        {
            speed = wojtek;
        }
    }

    public void respawn()
    {
        if (!isAlive())
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(2);          //bylo 1
        }
    }
    public Boolean isAlive()
    {
        if (health <= 0 || drugWithdrawal <= 0 || poisoning > 40)
            return false;
        if (health > 0 && drugWithdrawal > 0 && poisoning <= 40)
            return true;
        return false;
    }

    //test
}
