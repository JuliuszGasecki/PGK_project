using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarcoManager : MonoBehaviour {

    DrugsTimer dt;
    public GameObject alcoHera;
    bool alcoHeraFlag = false;
    bool alcoHeraIsInUse = false;

	// Use this for initialization
	void Start () {
		dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
    }
	
	// Update is called once per frame
	void Update () {
        checkMix();
        pushMix();
		
	}
    private void pushMix()
    {
        if(alcoHeraFlag == true && alcoHeraIsInUse == false)
        {
            alcoHeraIsInUse = true;
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

}
