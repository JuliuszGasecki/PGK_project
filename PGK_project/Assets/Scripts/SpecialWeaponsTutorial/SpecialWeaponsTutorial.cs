using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeaponsTutorial : MonoBehaviour
{
    public bool IsActive { set; get; }
    private int SpaceCount = 0;
    public GameObject tutorial;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (IsActive)
	    {
	        tutorial.SetActive(true);
	        Time.timeScale = 0f;
            IsActive = !IsActive;
	    }
	}

    void SpaceController()
    {

    }
}
