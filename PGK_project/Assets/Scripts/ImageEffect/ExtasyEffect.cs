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
    private PostProcessingBehaviour effect;
    // Use this for initialization
    void Start () {
        effect = GetComponent<PostProcessingBehaviour>();
    }

	// Update is called once per frame
	void Update () {

        if(hero.vodkaFlag)
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
