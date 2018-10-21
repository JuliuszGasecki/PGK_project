using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    public float bulletDamage;

	// Use this for initialization
	void Start ()
	{
	    //StartCoroutine(SelfDestruct());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
