using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoLights : MonoBehaviour {

    public float colorChangeRatio;
    public float ColorSeed;
    public float resizeRatio;

    private float time;
    private SpriteRenderer spriteRenderer;
    // Use this for initialization
    void Start () {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        ChangeColor();

    }

    private void ChangeColor()
    {
        float r = Mathf.Sin(colorChangeRatio * Time.time)/ColorSeed;
        float b = Mathf.Cos(colorChangeRatio * Time.time + 3) / ColorSeed;
        spriteRenderer.color = new Vector4(r, 0, b, 0.4f);
    }


}
