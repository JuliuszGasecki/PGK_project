﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour {

    private float time;
    public static string nameScene = "Home";

    void Start()
    {
        time = Time.time;
    }

    void Update()
    {
        if(Time.time - time > 4)
        {
            DrugsStat.AllStatsReset();
            SceneManager.LoadScene(nameScene);
           // SceneManager.LoadScene("home");
        }
    }

}
