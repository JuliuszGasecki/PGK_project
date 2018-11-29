using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnButton : MonoBehaviour {
    public void Return()
    {
        Time.timeScale = 1.0f;
        DrugsStat.drugsAlcoValue = 0;
        DrugsStat.drugsCocaValue = 0;
        DrugsStat.drugsExtasyValue = 0;
        DrugsStat.drugsHeraValue = 0;
        DrugsStat.drugsMariValue = 0;
        DrugsStat.drugsValue = 0;
        KilledStat.killedValue = 0;
        ScoreCounter.scoreValue = 0;        //na deathscene widac pkt, po wcisnieciu return zerujemy
        SceneManager.LoadScene(1);
    }
}
