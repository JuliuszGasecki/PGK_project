using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public int health;
    public float speed;
    public int poisoning;
    public int drugWithdrawal;
    public float attack;

    public Transform spawnPoint;

    private int tempHealth;

    private float tempSpeed;

    private int tempPoisoning;

    private int tempDrugWithdrawal;

    private float tempAttack;

    // Use this for initialization
    void Start ()
    {
        this.transform.position = spawnPoint.position;
        tempHealth = health;
        tempSpeed = speed;
        tempPoisoning = poisoning;
        tempDrugWithdrawal = drugWithdrawal;
        tempAttack = attack;
    }

	// Update is called once per frame
	void Update () {
		
	}

    void respawn()
    {
        if (!isAlive())
        {

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
