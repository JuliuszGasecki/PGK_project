using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTest : MonoBehaviour {

    public void nextLevelButton(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1f;
    }

}
