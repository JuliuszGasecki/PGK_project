using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTest : MonoBehaviour {

    public void nextLevelButton(string name)
    {
        
        DrugsStat.AllStatsReset();
        if (AddCompletedLevel())
        {
            LoadingScreenManager.nameScene = name;
            SceneManager.LoadScene("LoadingScreen");
        }
        Time.timeScale = 1f;
    }

    public bool AddCompletedLevel()
    {
        Debug.Log("LEVELLLLL : " + DrugsStat.level);
        if (!DrugsStat.openedLvls.Contains(DrugsStat.level))
        {
            DrugsStat.openedLvls.Add(DrugsStat.level);
            DrugsStat.level++;
            Debug.Log("TRUEEEE");
            return true;
        }
        else
        {
            LoadingScreenManager.nameScene = "LevelsMap";
            SceneManager.LoadScene("LoadingScreen");
            return false;
        }
    }

}
