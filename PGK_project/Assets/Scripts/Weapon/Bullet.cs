using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    public int bulletDamage;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
	}
    void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<Hero>().health -= bulletDamage;
        }
        if(collision.gameObject.tag == "Enemy"){
            collision.gameObject.GetComponent<Enemy>().zycie -= bulletDamage;
            
        }
        Destroy(gameObject);
    }

}
