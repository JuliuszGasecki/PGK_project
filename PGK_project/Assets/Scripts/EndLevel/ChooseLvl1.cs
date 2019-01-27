using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLvl1 : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DrugsStat.level = 3;                                // lvl to reach
            if (!DrugsStat.openedLvls.Contains(2))              // reached lvl
            {
                DrugsStat.openedLvls.Add(2);
                LevelsStatistic.Level level = new LevelsStatistic.Level(2, 0, 0, true, 0, 0, 0);
                LevelsStatistic.level_repo.Add(level);
            }
            SceneManager.LoadScene("LevelsMap");
        }
    }
}
