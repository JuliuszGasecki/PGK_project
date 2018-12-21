using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowBullet : MonoBehaviour
{
    public float bulletSpeed { set; get; }

    public int bulletDamage { set; get; }
    public GameObject BulletSplash;

    // Use this for initialization
    void Start()
    {
        // bulletDamage = 3;
        //bulletSpeed = 20f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        var tag = collision.gameObject.tag;

        if (tag == "Enemy")
        {
            //ustaw specjalny efekt
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
