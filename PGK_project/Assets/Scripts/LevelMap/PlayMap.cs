using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMap : MonoBehaviour {

    public void playMapDemo()
    {
        LoadingScreenManager.nameScene = "DemoScene";
        SceneManager.LoadScene("LoadingScreen");
        Inventory inv = GameObject.Find("Hero").GetComponent<Inventory>();
        inv.GetUsingWeapon().CanUse = false;
    }

    public void playLoadingScreen()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

    public void playMapHome()
    {
        LoadingScreenManager.nameScene = "Home";
        SceneManager.LoadScene("LoadingScreen");
        Inventory inv = GameObject.Find("Hero").GetComponent<Inventory>();
        inv.GetUsingWeapon().CanUse = false;
    }
}
