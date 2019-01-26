using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyHelper : MonoBehaviour {

    public SpriteRenderer image;

	// Update is called once per frame
	void Update () {
		if(this.gameObject.GetComponent<Enemy2>().life<=0)
        {
            image.enabled = false;
        }
	}
}
