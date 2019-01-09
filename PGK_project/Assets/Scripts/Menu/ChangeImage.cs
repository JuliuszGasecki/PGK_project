using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour {

    public List<Sprite> images;
    public float timeToChange;
    public Image image;
    private float time;
    private int currentIndex;
	// Use this for initialization
	void Start () {
        time = Time.time;
        currentIndex = 0;
        image.sprite = images[currentIndex];
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - time > (currentIndex + 1) * timeToChange)
        {
            Debug.Log(currentIndex);
            image.sprite = images[currentIndex];
            currentIndex++;
        }
        indexOverflow();
	}

    private void indexOverflow()
    {
        if(currentIndex == images.Count)
        {
            currentIndex = 0;
            time = Time.time;
        }
    }
}
