using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTags : MonoBehaviour {


    public GameObject tag0;
    public GameObject tag1;
    public GameObject tag2;

    void Start () {

        tag0.SetActive(true);
        foreach (var item in DrugsStat.openedLvls)
        {
            if (item == 0)
                tag1.SetActive(true);
            if (item == 1)
                tag2.SetActive(true);
          //  if (item == 2)
                //tag2.SetActive(true);
        }
	}
	
	void Update () {
		
	}
}
