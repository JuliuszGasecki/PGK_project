using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class loadingScreenScript : MonoBehaviour {

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


    private PostProcessingBehaviour effect;
    private float time;

    // Use this for initialization
    void Start () {
        effect = GetComponent<PostProcessingBehaviour>();
        time = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Time.time - time);
        if(Time.time - time <= 0.3f && effect.profile != extasyProfile)
        {
            GetComponent<PostProcessingBehaviour>().profile = extasyProfile;
        }else if(Time.time - time <= 0.5f && effect.profile != WeedProfile)
        {
            GetComponent<PostProcessingBehaviour>().profile = WeedProfile;
        }
        else if (Time.time - time <= 0.7)
        {
            GetComponent<PostProcessingBehaviour>().profile = cocaProfile;
        }
        else if (Time.time - time <= 0.9)
        {
            GetComponent<PostProcessingBehaviour>().profile = alcoProfile;
        }
        else if (Time.time - time <= 1.1)
        {
            GetComponent<PostProcessingBehaviour>().profile = heraProfile;
        }
        else if (Time.time - time <= 1.4)
        {
            GetComponent<PostProcessingBehaviour>().profile = lsdProfile;
        }
        else if (Time.time - time <= 1.7)
        {
            GetComponent<PostProcessingBehaviour>().profile = heraAlcoProfile;
        }
        else if (Time.time - time <= 1.9)
        {
            GetComponent<PostProcessingBehaviour>().profile = heraCocaProfile;
        }
        else if (Time.time - time <= 2.2)
        {
            GetComponent<PostProcessingBehaviour>().profile = cocaMaryProfile;
        }
        else if (Time.time - time <= 2.6)
        {
            GetComponent<PostProcessingBehaviour>().profile = cocaMdmaProfile;
        }
        

	}
}
