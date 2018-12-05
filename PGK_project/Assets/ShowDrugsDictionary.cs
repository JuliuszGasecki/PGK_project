using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDrugsDictionary : MonoBehaviour {

    float actual_time_scale;
    public GameObject container;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.F))
        {
            actual_time_scale = Time.timeScale;
            this.GetComponent<Image>().enabled = true;
            Time.timeScale = 0.0f;
            container.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            Time.timeScale = actual_time_scale;
            this.GetComponent<Image>().enabled = false;
            container.SetActive(false);
        }

    }
}
