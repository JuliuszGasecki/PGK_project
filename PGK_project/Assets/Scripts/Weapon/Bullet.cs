using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed { set; get; }

    public int bulletDamage { set; get; }
    public GameObject BulletSplash;
    public GameObject BloodSplash;

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
        var tag = collision.gameObject.tag;
        if(tag == "Player"){
            collision.gameObject.GetComponent<Hero>().health -= bulletDamage;
            //Instantiate(BloodSplash, collision.gameObject.GetComponent<Renderer>().bounds.center, Quaternion.identity);
        }
        if(tag == "Enemy"){
            collision.gameObject.GetComponent<Enemy>().zycie -= bulletDamage;
            Instantiate(BloodSplash, collision.gameObject.GetComponent<Renderer>().bounds.center, Quaternion.identity);
        }

        if (tag != "Ammo")
        {
            if (tag != "Player" && tag != "Enemy")
            {
                Instantiate(BulletSplash, this.transform.position, Quaternion.identity);
            }
        }
            Destroy(gameObject);
    }

}
