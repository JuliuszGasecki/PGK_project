using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugsTimer : MonoBehaviour {

    Hero hero;
   Withdrawal heroW;
    public bool tookDrug = false;


    public Slider extasySlider;
    public float extasyTime = 0f;
    public bool extasyFlag = false;

    public Slider marihuanaSlider;
    public float marihuanaTime = 0f;
    public bool marihuanaFlag = false;

    // Use this for initialization
    void Start () {
        hero = GetComponent<Hero>();
        heroW  =GetComponent<Withdrawal>();
		
	}
	
	// Update is called once per frame
	void Update () {
        checkExtasy();
        checkMarihuana();
    }

    public void addExtasyTime()
    {
        extasyTime += 20f;
    }
    private void checkExtasy()
    {
        if(extasyTime>0)
        {
            tookDrug = true;
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
        heroW.addWithdrawalPoints(7);
    }
    private void resetExtasy()
    {
        hero.speed -= 5;
        heroW.addWithdrawalPoints(5);
    }

    public void addMarihuanaTime()
    {
        marihuanaTime += 50f;
    }
    private void checkMarihuana()
    {
        if (marihuanaTime > 0)
        {
            tookDrug = true;
            marihuanaTime -= Time.fixedDeltaTime;
            marihuanaSlider.value = marihuanaTime;
            if (marihuanaFlag == false)
            {
                useMarihuana();
            }
            marihuanaFlag = true;
        }
        else if (marihuanaFlag == true)
        {
            resetMarihuana();
            marihuanaFlag = false;
        }
    }

    private void useMarihuana()
    {
        Time.timeScale = 0.2f;
        hero.speed += 5;
        heroW.stopWithdrawal();

    }
    private void resetMarihuana()
    {
        Time.timeScale = 1f;
        hero.speed -= 5;
        heroW.startWithdrawal();
        heroW.addWithdrawalPoints(10);
    }

}
