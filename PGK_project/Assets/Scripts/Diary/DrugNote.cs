using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugNote : MonoBehaviour {

    public string _name;
    public Sprite narcoSprite;
    public string explenation;
    public bool isDiscovered;

	// Use this for initialization
	void Start () {
        DrugsDiary.DrugsDiaryInstance.drugs.Add(this);
    }
}
