using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed { set; get; }

    public int bulletDamage { set; get; }

	// Use this for initialization
	void Start ()
	{
       // bulletDamage = 3;
        //bulletSpeed = 20f;
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
