using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMap : MonoBehaviour {

    public void playMapDemo()
    {
        if (DrugsStat.openedLvls.Contains(0))
        {
            DrugsStat.level = 0;
            LoadingScreenManager.nameScene = "DemoScene";
            PlayLoadingScreen();
            // Inventory inv = GameObject.Find("Hero").GetComponent<Inventory>();
            //inv.GetUsingWeapon().CanUse = false;
        }
    }

    public void playMapHome()
    {
        if (DrugsStat.openedLvls.Contains(1))
        {
            LoadingScreenManager.nameScene = "Home";
            PlayLoadingScreen();
            // Inventory inv = GameObject.Find("Hero").GetComponent<Inventory>();
            //inv.GetUsingWeapon().CanUse = false;
            DrugsStat.level = 1;
        }
    }

    public void PlayMapDisco()
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
