using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTest : MonoBehaviour {

    public static Dictionary<string, int> levelNameNumer = new Dictionary<string, int>()
    {
        { "Demo", 0 },
        { "Home", 1 },
        { "Disco", 2 }
    };

    public void NextLevelButton(string name)
    {
        DrugsStat.AllStatsReset();
        if (AddCompletedLevel())
        {
            DrugsStat.level = levelNameNumer.FirstOrDefault(x => x.Key == name).Value;
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
