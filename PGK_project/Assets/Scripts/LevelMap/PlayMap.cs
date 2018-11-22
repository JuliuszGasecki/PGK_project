using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMap : MonoBehaviour {

    public void playMapDemo()
    {
        SceneManager.LoadScene("DemoScene");
    }

    public void playLoadingScreen()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

    public void playMapHome()
    {
        SceneManager.LoadScene("Home");
    }
}
