using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsBackButton : MonoBehaviour {

    public void BackButton(string name)
    {
        SceneManager.LoadScene(name);
    }
}
