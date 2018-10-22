using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour {

    private string spriteWeapon = "hero_weapon";
    private string spriteHero = "hero_knife";
    private SpriteRenderer spriteR;
    private bool isChange;
    private float change_freeze = 0.1f;
    private float timer;
    void Start()
    {
        isChange = true;
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        timer = Time.time;
    }


    // Update is called once per frame
    void Update () {
        if (timer < Time.time)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (isChange)
                {
                    spriteR.sprite = Resources.Load<Sprite>(spriteHero);
                    isChange = false;
                    this.GetComponent<Hero>().canShoot = false;

                }
                else
                {
                    spriteR.sprite = Resources.Load<Sprite>(spriteWeapon);
                    isChange = true;
                    this.GetComponent<Hero>().canShoot = true;
                }
            }

            timer = Time.time + change_freeze;
        }
    }
}
