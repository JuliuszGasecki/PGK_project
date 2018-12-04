using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timer;
    public Text timerStat;
    private float startTime;
    public float t;
    public string minutes;
    public string seconds;
    public static float time;


    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        time = Time.time - startTime;
        t = Time.time - startTime;

        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f2");
        Debug.Log("CZASSSSSSSSSS:               " + time);
        timer.text = minutes + ":" + seconds;
        timerStat.text = minutes + ":" + seconds;
    }
}
