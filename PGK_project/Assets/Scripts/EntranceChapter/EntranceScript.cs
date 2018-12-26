using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntranceScript : MonoBehaviour {

    private float time;
    private Text chapterText;
    private Text dateText;
    private Text dayOfDrugString;
    private Image background;
    private Image chapterImage;

    private Hero hero;
    private float previousSpeed;

    public Sprite chapterSprite;

	// Use this for initialization
	void Start () {
        time = Time.time;
        chapterText = GameObject.Find("ChapterText").GetComponent<Text>();
        dateText = GameObject.Find("Date").GetComponent<Text>();
        dayOfDrugString = GameObject.Find("DrugString").GetComponent<Text>();
        background = GameObject.Find("BG").GetComponent<Image>();
        //chapterImage = GameObject.Find().GetComponent<Image>();
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        previousSpeed = hero.speed;
        hero.speed = 0;
    }
	
	// Update is called once per frame
	void Update () {
        changeTransparency();
        if (Time.time - time > 20)
        {
            chapterText.enabled = false;
            dateText.enabled = false;
            dayOfDrugString.enabled = false;
            background.enabled = false;
            hero.speed = previousSpeed;
            Destroy(gameObject);
        }
            

    }

    private void changeTransparency()
    {
        chapterText.color = new Vector4(chapterText.color.r, chapterText.color.g, chapterText.color.b, 1);
        dateText.color = new Vector4(chapterText.color.r, chapterText.color.g, chapterText.color.b, function(Time.time - time));
        dayOfDrugString.color = new Vector4(chapterText.color.r, chapterText.color.g, chapterText.color.b, function(Time.time - time - 3));
        background.color = new Vector4(background.color.r, background.color.g, background.color.b, 1 - function(Time.time - time - 10));
    }

    private float function(float time)
    {
        float temp = time / 10;
        if(temp > 1.3f)
        {
            return temp / (temp+1);
        }
        if (temp > 1)
            return 1;
        else return temp;
    }

}
