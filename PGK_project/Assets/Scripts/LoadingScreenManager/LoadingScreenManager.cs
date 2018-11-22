using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour {

    float time;

    void Start()
    {
        time = Time.time;
    }

    void Update()
    {
        if(Time.time - time > 2)
        {
            SceneManager.LoadScene("Home");
        }
    }

}
