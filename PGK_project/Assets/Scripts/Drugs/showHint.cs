using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHint : MonoBehaviour {

    public GameObject go;
    Image image;

    void Start()
    {
        image = go.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update () {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            image.enabled = true;
            Debug.Log("kolizja!");
        }
            
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            image.enabled = false;
    }
}
