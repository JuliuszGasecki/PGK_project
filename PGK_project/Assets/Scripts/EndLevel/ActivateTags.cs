﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTags : MonoBehaviour {


    public GameObject tag0;         // home                      demo lvl_0
    public GameObject tag0Done;
    public GameObject tag1;         // home lvl_1
    public GameObject tag1Done;
    public GameObject tag2;         // disco lvl_2
    public GameObject tag2Done;
    public GameObject tag3;         // metro lvl_3
    public GameObject tag3Done;

    void Start () {

        tag0.SetActive(true);
        foreach (var item in DrugsStat.openedLvls)
        {
            if (item == 0)                  // when lvl_0 is completed
            {
                tag1.SetActive(true);       // tag1 is active(lvl_1)
                tag0Done.SetActive(true);
            }
            if (item == 1)                  // when lvl_1 is completed
            {
                tag2.SetActive(true);       // tag2 is active(lvl_2)
                tag1Done.SetActive(true);
            }
            if (item == 2)                  // when lvl_2 is completed
            {
                tag3.SetActive(true);       // tag3 is active(lvl_3)
                tag2Done.SetActive(true);
            }
        }
	}
	
	void Update () {
		
	}
}
