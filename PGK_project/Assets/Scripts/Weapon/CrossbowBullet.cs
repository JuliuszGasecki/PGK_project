using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossbowBullet : MonoBehaviour
{
    private SpriteRenderer sprite;
    public float bulletSpeed { set; get; }

    public int specialEffect { set; get; }

    private List<Action> functions;

    public GameObject BulletSplash;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        // bulletDamage = 3;
        //bulletSpeed = 20f;
        functions = new List<Action>();
        functions.Add(GreenArrowsEffects);
        functions.Add(RedArrowsEffects);
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

    void GreenArrowsEffects()
    {

    }

    void RedArrowsEffects()
    {

    }
}
