using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLvl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            DrugsStat.level=2;
            if (!DrugsStat.openedLvls.Contains(1))
            {
                DrugsStat.openedLvls.Add(1);
                LevelsStatistic.Level level = new LevelsStatistic.Level(1, 0, 0, true, 0,0,0);
                LevelsStatistic.level_repo.Add(level);
            }
            SceneManager.LoadScene("LevelsMap");
        }
    }
}
