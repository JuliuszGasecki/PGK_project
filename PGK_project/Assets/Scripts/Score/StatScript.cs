using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScript : MonoBehaviour {


    public GameObject summary;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Tab))
        {
            summary.SetActive(true);
        }
        else
        {
            summary.SetActive(false);
        }
    }
}
