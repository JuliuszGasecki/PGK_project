using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip startMission;
    public AudioClip onDrugs;
    public AudioClip onWeed;
    public DrugsTimer hero;
    // Use this for initialization
    private bool startFlag = false;
    private bool onDrugsFlag = false;
    private bool onWeedFlag = false;
    void Start () {
        audioSource.clip = startMission;
        audioSource.Play();
        startFlag = true;
}
	
	// Update is called once per frame
	void Update () {

        audioSource.volume = SettingsManager.sliderValue;

        if (hero.onDrugs == true)
        {
            if (startFlag == true)
            {
                audioSource.Stop();
                startFlag = false;
                audioSource.clip = onDrugs;
                audioSource.Play();
                onDrugsFlag = true;
            }

            if (hero.marihuanaFlag == true)
            {
                if (onDrugsFlag == true)
                {
                    audioSource.Stop();
                    onDrugsFlag = false;
                    audioSource.clip = onWeed;
                    audioSource.Play();
                }


            }
            else if (onDrugsFlag == false)
            {
                audioSource.Stop();
                audioSource.clip = onDrugs;
                audioSource.Play();
                onDrugsFlag = true;
            }
        }
              
	}
}
