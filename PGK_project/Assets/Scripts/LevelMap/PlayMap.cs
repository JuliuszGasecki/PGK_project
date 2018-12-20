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
            SceneManager.LoadScene("Home");                     // load scene without LoadingScene
            // Inventory inv = GameObject.Find("Hero").GetComponent<Inventory>();
            //inv.GetUsingWeapon().CanUse = false;
            DrugsStat.level = 1;
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

    public void PlayLoadingScreen()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
}
