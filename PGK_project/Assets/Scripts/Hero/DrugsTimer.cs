using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugsTimer : MonoBehaviour {

    public Slider extasySlider;
    public float extasyTime = 0f;
    private bool extasyFlag = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        useExtasy();


    }

    public void addExtasyTime()
    {
        extasyTime += 10f;
    }
    private void useExtasy()
    {
        if(extasyTime>0)
        {
            extasyTime -= Time.fixedDeltaTime;
            extasySlider.value = extasyTime;
            extasyFlag = true;
        }
        else
            extasyFlag = false;
    }

}
