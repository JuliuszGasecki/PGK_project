﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugTemplate : MonoBehaviour {

    public string nazwa;
    Hero hero;
    public GameObject drugEffect;
    DrugsTimer heroDrugTimer;
    private float angle = 0;
    float time = 0;
    public float speedBoost;
    public int lifeBoost;
    public float attackBoost;
    float timeofuse;
    public float lifetime;
    public float withdroval_points;
    public float poison_points;
    public float time_scale;
    public float timeLeft;

    public bool flag_ifUsed{
        set; get;
    }
    


    public void setTimeOfUse(float time){
        timeofuse = time;
        timeLeft = lifetime - timeofuse;
    }
    public void addTimeofuse(float time)
    {
        timeofuse += time;
    }

    public float getTimeOfUse()
    {
        return timeofuse;
    }

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Use this for initialization
    void Start () {
        flag_ifUsed = false;
    }
    
    // Update is called once per frame
    void Update () {
        bounce();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && this.gameObject.tag == "Stimulants")
        {
            hero = collision.GetComponent<Hero>();
            heroDrugTimer = collision.GetComponent<DrugsTimer>();
            if (Input.GetMouseButton(1) || Input.GetKeyDown(KeyCode.E))
            {
                if (drugEffect != null)
                    Instantiate(drugEffect);
                destroyObject();
                heroDrugTimer.addNarcotic(this);
            }
        }
        

    }


    private void bounce()
    {
        float lastY = transform.position.y;
        transform.position = new Vector2(transform.position.x, lastY + Mathf.Sin(angle) / 80);
        angle += 3.14f / 64f;
    }

    public void destroyObject()
    {
        Destroy(gameObject);
    }
}
