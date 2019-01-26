using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkImageFinalScene : MonoBehaviour {
    public float seed;

    void Start()
    {
    }

    void Update()
    {
        if (Mathf.Sin(Time.time * seed) > 0.9)
        {
            this.gameObject.GetComponent<Image>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<Image>().enabled = false;
        }
    }
}
