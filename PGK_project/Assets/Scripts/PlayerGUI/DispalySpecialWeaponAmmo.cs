﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispalySpecialWeaponAmmo : MonoBehaviour
{
    private Inventory weapon;
    private Image image;
    private Sprite sprite;
    private List<string> _arrowNames;
    public float FirstPosX;
    public float FirstPosY;
    public float Width;
    public int indexArrow { set; get; }

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        _arrowNames = new List<string>(new string[] {"arrow1r", "arrow2g"});
    }

    // Update is called once per frame
    void Update()
    {
        weapon = GameObject.Find("Inventory").GetComponent<Inventory>();
        if (weapon.GetUsingSpecialWeapon() == null)
        {
            image.enabled = false;
        }
        else if (Time.timeScale == 0f) //usun icon w summaryPanel
        {
            image.enabled = false;
        }
        else
        {
            //indexArrow = weapon.GetComponent<CROSSBOW>().NarcoMixId;
            if (indexArrow >= 0)
            {
                image.enabled = true;
                image.type = Image.Type.Filled;
                image.fillMethod = Image.FillMethod.Radial360;
                image.sprite = Resources.Load<Sprite>("Weapons/" + _arrowNames[indexArrow]);           
            }
        }
    }
}