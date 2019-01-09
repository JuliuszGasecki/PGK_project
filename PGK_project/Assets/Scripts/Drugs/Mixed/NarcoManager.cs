using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NarcoManager : MonoBehaviour {

    //Achievments
    public AchievementsControllScript achievementsControllScript;

    public GameObject deathScene;
    DrugsTimer dt;
    //Alkohol i heroina
    public GameObject alcoHera;
    public bool alcoHeraFlag { set; get; }
    bool alcoHeraIsInUse = false;
    public Sprite alcHer;

    //Heroina i kokaina
    public GameObject cocoHera;
    public bool cocoHeraFlag { set; get; }
    bool cocoHeraIsInUse = false;
    public Sprite cocHer;

    //Alkohol i kokaina/MDMA
    public GameObject alcoSpeed;
    public bool alcoSpeedFlag { set; get; }
    bool alcoSpeedIsInUse = false;
    public Sprite alcSpe;

    //Koka + Mary
    public GameObject cocoMary;
    public bool cocoMaryFlag { set; get; }
    bool cocoMaryIsInUse = false;
    public Sprite cocMar;

    //Koka + MDMA
    public GameObject cocoMDMA;
    public bool cocoMDMAFlag { set; get; }
    bool cocoMDMAIsInUse = false;
    public Sprite cocMda;

    //Koka + LSD
    public GameObject cocoLSD;
    public bool cocoLSDFlag { set; get; }
    bool cocoLSDIsInUse = false;
    public Sprite cocLsd;

    //Cigarette + Mary
    public GameObject maryCigar;
    public bool maryCigarFlag { set; get; }
    bool maryCigarIsInUse = false;
    public Sprite marCig;

    //Hangover
    public Sprite hanOve;

    public Image image;

    float time = 0;

    // Use this for initialization
    void Start () {
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
        achievementsControllScript = GameObject.Find("Hero").GetComponent<AchievementsControllScript>();
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
            GlobalDrugsVariables.alcoHeraOnceTaken = true;
            time = Time.time;
            image.sprite = alcHer;
            image.enabled = true;
            Instantiate(alcoHera);
            achievementsControllScript.addMix("alcoHera");
        }
        if (cocoHeraFlag == true && cocoHeraIsInUse == false)
        {
            cocoHeraIsInUse = true;
            GlobalDrugsVariables.cocoHeraOnceTaken = true;
            //Debug.Log(GlobalDrugsVariables.cocoHeraOnceTaken);
            time = Time.time;
            image.sprite = cocHer;
            image.enabled = true;
            Instantiate(cocoHera);
            achievementsControllScript.addMix("cocoHera");
        }
        if (alcoSpeedFlag == true && alcoSpeedIsInUse == false)
        {
            alcoSpeedIsInUse = true;
            GlobalDrugsVariables.alcoSpeedOnceTaken = true;
            time = Time.time;
            image.sprite = alcSpe;
            image.enabled = true;
            Instantiate(alcoSpeed);
            achievementsControllScript.addMix("alcoSpeed");
        }
        if (cocoMaryFlag == true && cocoMaryIsInUse == false)
        {
            cocoMaryIsInUse = true;
            GlobalDrugsVariables.cocoMaryOnceTaken = true;
            time = Time.time;
            image.sprite = cocMar;
            image.enabled = true;
            Instantiate(cocoMary);
            achievementsControllScript.addMix("alcoSpeed");
        }
        if (cocoMDMAFlag == true && cocoMDMAIsInUse == false)
        {
            cocoMDMAIsInUse = true;
            GlobalDrugsVariables.cocoMDMAOnceTaken = true;
            time = Time.time;
            image.sprite = cocMda;
            image.enabled = true;
            Instantiate(cocoMDMA);
            achievementsControllScript.addMix("cocoMDMA");
        }
        if (cocoLSDFlag == true && cocoLSDIsInUse == false)
        {
            cocoLSDIsInUse = true;
            GlobalDrugsVariables.cocoLSDOnceTaken = true;
            time = Time.time;
            image.sprite = cocLsd;
            image.enabled = true;
            Instantiate(cocoLSD);
            achievementsControllScript.addMix("cocoLSD");
        }
        if (maryCigarFlag == true && maryCigarIsInUse == false)
        {
            maryCigarIsInUse = true;
            GlobalDrugsVariables.maryCigarOnceTaken = true;
            time = Time.time;
            image.sprite = marCig;
            image.enabled = true;
            Instantiate(maryCigar);
            achievementsControllScript.addMix("maryCigar");
        }
    }

    public void hangoverStart()
    {
        GlobalDrugsVariables.methHangoverOnceTaken = true;
        time = Time.time;
        image.sprite = hanOve;
        image.enabled = true;
    }

    private void checkMix()
    {
        //Alkohol + Heroina
        if (dt.vodkaFlag == true && dt.heroineFlag == true)
        {alcoHeraFlag = true;}
            
        else
        {
            alcoHeraFlag = false;
            alcoHeraIsInUse = false;
        }

        //Koko hera 
        if(dt.heroineFlag == true && dt.cocaFlag == true)
        {
            cocoHeraFlag = true;
        }
        else
        {
            cocoHeraFlag = false;
            cocoHeraIsInUse = false;
        }

        //Speed alco 
        if ((dt.vodkaFlag == true && dt.cocaFlag == true) || (dt.vodkaFlag == true && dt.extasyFlag == true))
        {
            alcoSpeedFlag = true;
        }
        else
        {
            alcoSpeedFlag = false;
            alcoSpeedIsInUse = false;
        }

        //Coco Mary
        if (dt.marihuanaFlag== true && dt.cocaFlag == true)
        {
            cocoMaryFlag = true;
        }
        else
        {
            cocoMaryFlag = false;
            cocoMaryIsInUse = false;
        }
        //Coco MDMA
        if (dt.extasyFlag == true && dt.cocaFlag == true)
        {
            cocoMDMAFlag = true;
        }
        else
        {
            cocoMDMAFlag = false;
            cocoMDMAIsInUse = false;
        }

        //Coco LSD
        if (dt.lsdFlag == true && dt.cocaFlag == true)
        {
            cocoLSDFlag = true;
        }
        else
        {
            cocoLSDFlag = false;
            cocoLSDIsInUse = false;
        }

        //Mary Cigarette
        if (dt.marihuanaFlag == true && dt.cigaretteFlag == true)
        {
            maryCigarFlag = true;
        }
        else
        {
            maryCigarFlag = false;
            maryCigarIsInUse = false;
        }

    }

    public void turnOffTheImage(float time)
    {
       // Debug.Log(time - Time.time);
        if(deathScene.active == true)
        {
            image.enabled = false;
        }
        float stop = 1f;
        if (image.sprite == cocHer)
            stop = 2f;
        if(Time.timeScale < 1.0f)
        {
            stop = 1.5f;
            if(Time.timeScale < 0.5f)
            {
                stop = 0.4f;
            }
            
        }
        if (Time.time - time > stop)
            image.enabled = false;
    }

}
