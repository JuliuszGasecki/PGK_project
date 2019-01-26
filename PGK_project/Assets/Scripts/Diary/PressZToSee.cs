using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressZToSee : MonoBehaviour {

    float time = -4;
    public void turnOnMessage()
    {
        time = Time.time;
        this.GetComponent<Text>().enabled = true;
    }

	void Update () {
		if(Time.time - time > 4)
        {
            this.GetComponent<Text>().enabled = false;
        }
        else if(this.GetComponent<Text>().enabled == true)
        {
            this.GetComponent<Text>().color = new Color(
                this.GetComponent<Text>().color.r,
                this.GetComponent<Text>().color.g,
                this.GetComponent<Text>().color.b,
                1-(Mathf.Sin(Time.time *4) + 1 / 2));
        }
	}
}
