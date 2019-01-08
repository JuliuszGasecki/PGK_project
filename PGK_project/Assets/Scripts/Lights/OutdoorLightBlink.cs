using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutdoorLightBlink : MonoBehaviour {

    public float blinkRatio;
    public float blinkSeed;

    private float time;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        time = Time.time;
        if(blinkRatio > 1)
        {
            blinkRatio = 1 / blinkRatio;
        }
        if(blinkRatio > 0.5)
        {
            blinkRatio = 1 - blinkRatio;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Blink();		
	}

    private void Blink()
    {
        float fun = function();
        //Debug.Log(fun);
        if(fun <= 1-blinkRatio && fun >= blinkRatio)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
        time = Time.time;
    }

    private float function()
    {
        return Mathf.Sin(time * blinkSeed);
    }
}
