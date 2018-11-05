using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    public Slider healthSlider;
    public int health;
    public float speed;
    public float poisoning;
    public float drugWithdrawal;
    public float attack;

    public Transform spawnPoint;

    private int tempHealth;

    private float tempSpeed;

    private float tempPoisoning;

    private float tempDrugWithdrawal;

    private float tempAttack;
    public bool canShoot { set; get; }

    // Use this for initialization
    void Start ()
    {
        canShoot = true;
        this.transform.position = spawnPoint.position;
        tempHealth = health;
        tempSpeed = speed;
        tempPoisoning = poisoning;
        tempDrugWithdrawal = drugWithdrawal;
        tempAttack = attack;
    }

	// Update is called once per frame
	void Update ()
	{
        healthSlider.value = health;
	    respawn();
        
	}

    void respawn()
    {
        if (!isAlive())
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(2);          //bylo 1
        }
    }
    Boolean isAlive()
    {
        if (health <= 0)
            return false;
        if (health > 0)
            return true;
        return false;
    }

}
