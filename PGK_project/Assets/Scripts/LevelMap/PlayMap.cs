using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMap : MonoBehaviour {



    public void PlayMapHome()
    {
        if (DrugsStat.openedLvls.Contains(0) && DrugsStat.openedLvls.Contains(1) && DrugsStat.openedLvls.Contains(2) && DrugsStat.openedLvls.Contains(3) && DrugsStat.openedLvls.Contains(4) && !DrugsStat.openedLvls.Contains(5))
        // when u completed lvl_0, you can join lvl_1 (demo)
        {
            DrugsStat.level = 4;
            LoadingScreenManager.nameScene = "Home 2";
            PlayLoadingScreen();

        }
        else if (DrugsStat.openedLvls.Contains(0) && DrugsStat.openedLvls.Contains(1) && DrugsStat.openedLvls.Contains(2) && !DrugsStat.openedLvls.Contains(3))                  // when u completed lvl_0, you can join lvl_1 (demo)
        {
            DrugsStat.level = 2;
            LoadingScreenManager.nameScene = "Home 1";
            PlayLoadingScreen();
        }
        else
        {
            DrugsStat.level = 0;
            LoadingScreenManager.nameScene = "Home";
            PlayLoadingScreen();
        }
    }
    public void PlayMapDemo()
    {
        if (DrugsStat.openedLvls.Contains(0))                   // when u completed lvl_0, you can join lvl_1 (demo)
        {
            DrugsStat.level = 1;
            LoadingScreenManager.nameScene = "DemoScene";
            PlayLoadingScreen();
        }
    }

    public void PlayMapDisco()                                  // when u completed lvl_0 and lvl_1, you can join lvl_2 (disco)
    {
        if (DrugsStat.openedLvls.Contains(2) && DrugsStat.openedLvls.Contains(1) && DrugsStat.openedLvls.Contains(0))
        {
            DrugsStat.level = 3;
            LoadingScreenManager.nameScene = "Disco";
            PlayLoadingScreen();
        }
    }

    public void PlayMapMetro()                                 // when u completed lvl_0, lvl_1 and lvl_2, you can join lvl_3 (metro)
    {
        if (DrugsStat.openedLvls.Contains(2) && DrugsStat.openedLvls.Contains(1) && DrugsStat.openedLvls.Contains(0))
        {
            DrugsStat.level = 3;
            LoadingScreenManager.nameScene = "Metro";
            PlayLoadingScreen();
        }
    }


    public void PlayLastMap()
    {
       // DrugsStat.level = 0;
        if(DrugsStat.level == 0)
        {
            LoadingScreenManager.nameScene = "Home";
            PlayLoadingScreen();
        }
        else if(DrugsStat.level == 1)
        {
            LoadingScreenManager.nameScene = "DemoScene";
            PlayLoadingScreen();
        }
        else if (DrugsStat.level == 2)
        {
            LoadingScreenManager.nameScene = "Home 1";
            PlayLoadingScreen();
        }
        else if (DrugsStat.level == 3)
        {
            LoadingScreenManager.nameScene = "Disco";
            PlayLoadingScreen();
        }
        else if (DrugsStat.level == 4)
        {
            LoadingScreenManager.nameScene = "Home 2";
            PlayLoadingScreen();
        }
        else if (DrugsStat.level == 5)
        {
            LoadingScreenManager.nameScene = "Metro";
            PlayLoadingScreen();
        }
    }

    public void PlayLoadingScreen()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
}
