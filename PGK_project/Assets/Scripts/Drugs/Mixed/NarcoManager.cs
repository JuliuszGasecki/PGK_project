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

    public Image image;

    float time = 0;

    // Use this for initialization
    void Start () {
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.fixedDeltaTime;
        turnOffTheImage(time);
        checkMix();
        pushMix();
		
	}
    private void pushMix()
    {
        if(alcoHeraFlag == true && alcoHeraIsInUse == false)
        {
            alcoHeraIsInUse = true;
            time = 0;
            image.sprite = alcHer;
            image.enabled = true;
            Instantiate(alcoHera);
        }
        if (cocoHeraFlag == true && cocoHeraIsInUse == false)
        {
            cocoHeraIsInUse = true;
            time = 0;
            image.sprite = cocHer;
            image.enabled = true;
            Instantiate(cocoHera);
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
        Debug.Log(time);
        if (time > stop)
            image.enabled = false;
    }

}
