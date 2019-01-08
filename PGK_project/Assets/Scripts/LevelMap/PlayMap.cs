using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMap : MonoBehaviour {


    public void PlayMapDemo()
    {
            DrugsStat.level = 0;
            LoadingScreenManager.nameScene = "DemoScene";
            PlayLoadingScreen();
            // Inventory inv = GameObject.Find("Hero").GetComponent<Inventory>();
            //inv.GetUsingWeapon().CanUse = false;
    }

    public void PlayMapHome()
    {
        if (DrugsStat.openedLvls.Contains(0))                   // when u completed lvl_0, you can join lvl_1 (home)
        {
            DrugsStat.level = 1;
            LoadingScreenManager.nameScene = "Home";
            PlayLoadingScreen();
            // SceneManager.LoadScene("Home");                     // load scene without LoadingScene
            // Inventory inv = GameObject.Find("Hero").GetComponent<Inventory>();
            //inv.GetUsingWeapon().CanUse = false;

        }
    }

    public void PlayMapDisco()                                  // when u completed lvl_0 and lvl_1, you can join lvl_2 (disco)
    {
        if (DrugsStat.openedLvls.Contains(1) && DrugsStat.openedLvls.Contains(0))
        {
            DrugsStat.level = 2;
            LoadingScreenManager.nameScene = "Disco";
            PlayLoadingScreen();
        }
    }

    public void PlayLastMap()
    {
       // DrugsStat.level = 0;
        if(DrugsStat.level == 0)
        {
            LoadingScreenManager.nameScene = "DemoScene";
            PlayLoadingScreen();
        }
        else if(DrugsStat.level == 1)
        {
            LoadingScreenManager.nameScene = "DemoScene";
            PlayLoadingScreen();
        }
        else if(DrugsStat.level == 2)
        {
            LoadingScreenManager.nameScene = "Home";
            PlayLoadingScreen();
        }
    }

    public void PlayLoadingScreen()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
}
