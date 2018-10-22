using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugsTimer : MonoBehaviour {

    public Hero hero;
    public Slider extasySlider;
    public float extasyTime = 0f;
    public bool extasyFlag = false;
    public Camera cameraEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        checkExtasy();
    }

    public void addExtasyTime()
    {
        extasyTime += 20f;
    }
    private void checkExtasy()
    {
        if(extasyTime>0)
        {
            extasyTime -= Time.fixedDeltaTime;
            extasySlider.value = extasyTime;
            if(extasyFlag == false)
            {
                useExtasy();
            }
            extasyFlag = true;
        }
        else if(extasyFlag == true)
        {
            resetExtasy();
            extasyFlag = false;
        }
    }
    private void useExtasy()
    {
        hero.speed += 5;
    }
    private void resetExtasy()
    {
        hero.speed -= 5;
    }

}
