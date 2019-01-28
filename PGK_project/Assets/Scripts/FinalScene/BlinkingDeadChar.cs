using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingDeadChar : MonoBehaviour
{

    private float time;
    // Use this for initialization
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Sin(Time.time * 2) > 0.5 && Mathf.Sin(Time.time * 2) < 0.85)
            this.GetComponent<Image>().enabled = true;
        else
            this.GetComponent<Image>().enabled = false;
        if (Time.time - time > 10)
        {
            Destroy(gameObject);
        }
    }
}
