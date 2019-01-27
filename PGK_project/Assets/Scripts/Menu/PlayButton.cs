using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

    public void PlayGame(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void PlayGameName(string name)
    {
        LoadingScreenManager.nameScene = "Required";
        SceneManager.LoadScene("LoadingScreen");
    }
}
