using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLvl2 : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DrugsStat.level = 5;                                // lvl to reach
            if (!DrugsStat.openedLvls.Contains(4))              // reached lvl
            {
                DrugsStat.openedLvls.Add(4);
                LevelsStatistic.Level level = new LevelsStatistic.Level(4, 0, 0, true, 0, 0, 0);
                LevelsStatistic.level_repo.Add(level);
            }
            SceneManager.LoadScene("LevelsMap");
        }
    }
}
