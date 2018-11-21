using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    public Slider sliderMusic;
    public AudioSource audio1;
    public static float sliderValue = 1;

    // Update is called once per frame
    void Update () {
        sliderValue = sliderMusic.value;
	}
}
