using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMap : MonoBehaviour {

    public void playMapDemo()
    {
        SceneManager.LoadScene("DemoScene");
        Inventory inv = GameObject.Find("Hero").GetComponent<Inventory>();
        inv.GetUsingWeapon().CanUse = false;
    }

    public void playLoadingScreen()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

    public void playMapHome()
    {
        SceneManager.LoadScene("Home");
        Inventory inv = GameObject.Find("Hero").GetComponent<Inventory>();
        inv.GetUsingWeapon().CanUse = false;
    }
}
