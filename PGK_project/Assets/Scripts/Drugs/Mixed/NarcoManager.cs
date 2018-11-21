using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NarcoManager : MonoBehaviour {

    public GameObject deathScene;
    DrugsTimer dt;
    //Alkohol i heroina
    public GameObject alcoHera;
    bool alcoHeraFlag = false;
    bool alcoHeraIsInUse = false;
    public Sprite alcHer;

    //Heroina i kokaina
    public GameObject cocoHera;
    bool cocoHeraFlag = false;
    bool cocoHeraIsInUse = false;
    public Sprite cocHer;

    //Alkohol i kokaina/MDMA
    public GameObject alcoSpeed;
    bool alcoSpeedFlag = false;
    bool alcoSpeedIsInUse = false;
    public Sprite alcSpe;

    public Image image;

    float time = 0;

    // Use this for initialization
    void Start () {
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
    }
	
	// Update is called once per frame
	void Update () {
        turnOffTheImage(time);
        checkMix();
        pushMix();
		
	}
    private void pushMix()
    {
        if(alcoHeraFlag == true && alcoHeraIsInUse == false)
        {
            alcoHeraIsInUse = true;
            time = Time.time;
            image.sprite = alcHer;
            image.enabled = true;
            Instantiate(alcoHera);
        }
        if (cocoHeraFlag == true && cocoHeraIsInUse == false)
        {
            cocoHeraIsInUse = true;
            time = Time.time;
            image.sprite = cocHer;
            image.enabled = true;
            Instantiate(cocoHera);
        }
        if (alcoSpeedFlag == true && alcoSpeedIsInUse == false)
        {
            alcoSpeedIsInUse = true;
            time = Time.time;
            image.sprite = alcSpe;
            image.enabled = true;
            Instantiate(alcoSpeed);
        }
    }

    private void checkMix()
    {
        //Alkohol + Heroina
        if (dt.vodkaFlag == true && dt.heroineFlag == true)
        {alcoHeraFlag = true;}
            
        else
        {
            alcoHeraFlag = false;      
        }

        //Koko hera 
        if(dt.heroineFlag == true && dt.cocaFlag == true)
        {
            cocoHeraFlag = true;
        }
        else
        {
            cocoHeraFlag = false;
        }

        //Speed alco 
        if ((dt.vodkaFlag == true && dt.cocaFlag == true) || (dt.vodkaFlag == true && dt.extasyFlag == true))
        {
            alcoSpeedFlag = true;
        }
        else
        {
            alcoSpeedFlag = false;
        }

    }

    public void turnOffTheImage(float time)
    {
        if(deathScene.active == true)
        {
            image.enabled = false;
        }
        float stop = 1f;
        if (image.sprite == cocHer)
            stop = 2f;
        if (Time.time - time > stop)
            image.enabled = false;
    }

}
