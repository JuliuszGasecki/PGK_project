using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDialogueBackground : MonoBehaviour {

    Text text;
    public GameObject image;
    public GameObject image2;
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (text.text == null || text.text == "")
        {
            image.SetActive(false);
            image2.SetActive(false);
        }

        else
        {
            image.SetActive(true);
            image2.SetActive(true);
        }
            
	}
}
