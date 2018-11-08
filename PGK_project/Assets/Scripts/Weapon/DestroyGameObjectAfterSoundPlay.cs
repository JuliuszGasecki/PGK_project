using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjectAfterSoundPlay : MonoBehaviour
{
    private float timeBeforeDestroy;
    // Use this for initialization
    void Start ()
	{
	    var sound = this.GetComponent<AudioSource>();
	    timeBeforeDestroy = sound.clip.length;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timeBeforeDestroy -= Time.deltaTime;
	    if (timeBeforeDestroy <= 0f)
	    {
            Destroy(this.gameObject);
	    }

	}
}
