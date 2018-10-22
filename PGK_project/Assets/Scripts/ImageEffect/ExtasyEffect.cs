using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ExtasyEffect : MonoBehaviour {

    public DrugsTimer hero;
    private PostProcessingBehaviour effect;
    // Use this for initialization
    void Start () {
        effect = GetComponent<PostProcessingBehaviour>();
    }
	
	// Update is called once per frame
	void Update () {
        if (hero.extasyFlag == true)
        {
            effect.enabled = true;
        }
        else
            effect.enabled = false;
    }
}
