using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDialogueBackground : MonoBehaviour {

    Text text;
    public GameObject image;
    Text pressKeyText;
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
        pressKeyText = GameObject.Find("PressSpace").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (text.text == null || text.text == "")
        {
            image.SetActive(false);
            pressKeyText.enabled = false;
        }

        else
        {
            image.SetActive(true);
            pressKeyText.enabled = true;
        }
            
	}
}
