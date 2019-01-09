using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScreen : MonoBehaviour {

    public float whatTime;
    public float timeMod;
    private float time;
    public GameObject nextScreen;

    public List<Text> text;
    public List<Image> images;

	// Use this for initialization
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        if(Time.time - time >= whatTime*timeMod && Time.time - time >= whatTime)
        {
            nextScreen.SetActive(true);
            foreach (Text t in text)
            {
                t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a - 0.02f);
            }
            foreach (Image i in images)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - 0.03f);
            }
        }
		
	}
}
