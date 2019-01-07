using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ExtasyEffect : MonoBehaviour {

    public DrugsTimer hero;
    public PostProcessingProfile extasyProfile;
    public PostProcessingProfile noDrugProfile;
    public PostProcessingProfile WeedProfile;
    public PostProcessingProfile cocaProfile;
    public PostProcessingProfile alcoProfile;
    public PostProcessingProfile heraProfile;
    public PostProcessingProfile lsdProfile;
    public PostProcessingProfile heraAlcoProfile;
    public PostProcessingProfile heraCocaProfile;
    public PostProcessingProfile cocaMaryProfile;
    public PostProcessingProfile cocaMdmaProfile;
    public PostProcessingProfile cocaLsdProfile;
    public PostProcessingProfile maryCigarProfile;
    public PostProcessingProfile hangoverProfile;

    
    private PostProcessingBehaviour effect;
    // Use this for initialization
    void Start () {
        effect = GetComponent<PostProcessingBehaviour>();
    }

	// Update is called once per frame
	void Update () { 
        if(hero.cigaretteFlag && hero.marihuanaFlag)
        {
            GetComponent<PostProcessingBehaviour>().profile = maryCigarProfile;
        }       
        else if (hero.lsdFlag == true && hero.cocaFlag)
        {
            GetComponent<PostProcessingBehaviour>().profile = cocaLsdProfile;
        }
        else if (hero.lsdFlag == true)
        {
            GetComponent<PostProcessingBehaviour>().profile = lsdProfile;
        }
        else if (hero.vodkaFlag && hero.heroineFlag)
        {
            GetComponent<PostProcessingBehaviour>().profile = heraAlcoProfile;
        }
        else if (hero.heroineFlag && hero.cocaFlag)
        {
            GetComponent<PostProcessingBehaviour>().profile = heraCocaProfile;
        }
        else if (hero.cocaFlag && hero.marihuanaFlag)
        {
            GetComponent<PostProcessingBehaviour>().profile = cocaMaryProfile;
        }
        else if (hero.cocaFlag && hero.extasyFlag)
        {
            GetComponent<PostProcessingBehaviour>().profile = cocaMdmaProfile;
        }

        else if (hero.vodkaFlag)
        {
            GetComponent<PostProcessingBehaviour>().profile = alcoProfile;
        }
        else if(hero.heroineFlag)
        {
            GetComponent<PostProcessingBehaviour>().profile = heraProfile;
        }
        else if (hero.extasyFlag == true)
        {
            GetComponent<PostProcessingBehaviour>().profile = extasyProfile;
        }

        else if(hero.marihuanaFlag ==true)
        {
            GetComponent<PostProcessingBehaviour>().profile = WeedProfile;
        }
        else if(hero.cocaFlag == true)
        {
            GetComponent<PostProcessingBehaviour>().profile = cocaProfile;
        }
        

        else
            GetComponent<PostProcessingBehaviour>().profile = noDrugProfile;
    }
}
