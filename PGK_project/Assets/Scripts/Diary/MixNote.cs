using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixNote : MonoBehaviour {
    public string _name;
    public Sprite mixSprite;
    public Sprite firstNarcoSprite;
    public Sprite secondNarcoSprite;
    public string text;
    public bool isDiscovered = false;
	// Use this for initialization
	void Start () {
        DrugsDiary.DrugsDiaryInstance.mixes.Add(this);
    }


}
