using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public float temp;

	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();                //wlaczamy pause
            }
        }
            
		
	}

    public void Pause()
    {
        temp = Time.fixedDeltaTime;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.fixedDeltaTime = temp;
        Time.timeScale = 1f;
        GameIsPaused = false;
        temp = 0f;
    }
}
