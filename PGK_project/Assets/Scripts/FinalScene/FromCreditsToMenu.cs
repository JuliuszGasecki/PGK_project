using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromCreditsToMenu : MonoBehaviour
{

    private float time;
    // Use this for initialization
    void Start()
    {
        time = Time.time;

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time - time >= 100 || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("test");
        }

    }
}
