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
        if (SceneManager.GetActiveScene().name == name && DrugsStat.completed == false)             // powtorzenie, nie zaliczony lvl
            Do(name);
        else if (SceneManager.GetActiveScene().name == name && DrugsStat.completed == true)         // powtorzenie ale level zaliczony
        {
            if (!DrugsStat.openedLvls.Contains(DrugsStat.level))
            {
                DrugsStat.openedLvls.Add(DrugsStat.level);
            }
            Do(name);
        }
        else if (AddCompletedLevel())                                                               // nastepny level
        {
            Do(name);
            DrugsStat.completed = false;
        }
        Time.timeScale = 1f;
    }

    public void Do(string nameToDo)                             // do powtorzenia
    {
        DrugsStat.level = levelNameNumer.FirstOrDefault(x => x.Key == nameToDo).Value;
        LoadingScreenManager.nameScene = nameToDo;
        SceneManager.LoadScene("LoadingScreen");
    }
    public bool AddCompletedLevel()
    {
        LevelsStatistic.level_repo.OrderBy(x => x.Level_number).ThenByDescending(y => y.Level_points);
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
