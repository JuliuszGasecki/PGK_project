using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ExtasyEffect : MonoBehaviour {

    public DrugsTimer hero;
    public PostProcessingProfile extasyProfile;
    public PostProcessingProfile noDrugProfile;
    private PostProcessingBehaviour effect;
    // Use this for initialization
    void Start () {
        effect = GetComponent<PostProcessingBehaviour>();
    }
	
	// Update is called once per frame
	void Update () {
        if (hero.extasyFlag == true)
        {
            GetComponent<PostProcessingBehaviour>().profile = extasyProfile;
        }
        else
            GetComponent<PostProcessingBehaviour>().profile = noDrugProfile;
    }
}
