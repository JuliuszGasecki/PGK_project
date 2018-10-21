﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtasyScript : MonoBehaviour {

    public Hero hero;
    private float axis = 0;
    private bool playerOnTarget = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        bounce();
        if (playerOnTarget == true  && Input.GetMouseButton(1))
        {
            hero.poisoning += 1;
            hero.speed += 4;
            Debug.Log(hero.speed);
            destroyObject();
        }
    }

    private void bounce()
    {
        float lastY = transform.position.y;
        transform.position = new Vector3(transform.position.x, lastY + Mathf.Sin(axis)/40, transform.position.z);
        axis += 3.14f / 64f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerOnTarget = true;
        }
        else
            playerOnTarget = false;
    }



    private void destroyObject()
    {
        Destroy(gameObject);
    }
}
