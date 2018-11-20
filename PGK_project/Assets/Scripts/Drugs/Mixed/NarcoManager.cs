using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NarcoManager : MonoBehaviour {

    DrugsTimer dt;
    public GameObject alcoHera;
    bool alcoHeraFlag = false;
    bool alcoHeraIsInUse = false;
    public Image image;
    public Sprite alcHer;
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

    }

    public void turnOffTheImage(float time)
    {
        if (time > 0.8f)
            image.enabled = false;
    }

}
