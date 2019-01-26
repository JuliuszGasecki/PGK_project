using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneManager : MonoBehaviour {

    private float time;

    void Start()
    {
        time = Time.time;
    }

    void Update()
    {
        if (Time.time - time > 20)
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
