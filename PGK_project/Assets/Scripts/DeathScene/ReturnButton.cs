using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnButton : MonoBehaviour {
    public void Return()
    {
        Time.timeScale = 1.0f;
        DrugsStat.AllStatsReset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
       // Time.fixedDeltaTime = GameObject.Find("Hero").GetComponent<DeathScene>().temp;
    }
}
