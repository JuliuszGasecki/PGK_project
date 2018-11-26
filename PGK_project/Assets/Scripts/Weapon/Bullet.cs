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
            if (tag == "Player")
            {
                Debug.Log("xDDD");
                collision.gameObject.GetComponent<Hero>().health -= bulletDamage;
                 GameObject _blood = Instantiate(BloodSplash, collision.gameObject.GetComponent<Renderer>().bounds.center, Quaternion.identity) as GameObject;
                _blood.transform.parent = GameObject.Find("Hero").transform;
                _blood.transform.localScale = new Vector3(0.22f, 0.22f, 0.22f);
            }
        
        if (tag == "Enemy"){
            Instantiate(BloodSplash, collision.gameObject.GetComponent<Renderer>().bounds.center, Quaternion.identity * Quaternion.Euler(0, 0, 180));
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
