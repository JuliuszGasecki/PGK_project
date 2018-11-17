using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnButton : MonoBehaviour {
    public void Return()
    {
        ScoreCounter.scoreValue = 0;        //na deathscene widac pkt, po wcisnieciu return zerujemy
        SceneManager.LoadScene(1);
    }
}
