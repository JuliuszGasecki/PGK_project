using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethEffect : MonoBehaviour {

    private DrugsTimer drugsTimer;
    public GameObject hangover;
	// Use this for initialization
	void Start () {
        drugsTimer = GameObject.Find("Hero").GetComponent<DrugsTimer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!drugsTimer.methFlag)
        {
            Instantiate(hangover);
            Destroy(gameObject);
        }
	}
}
