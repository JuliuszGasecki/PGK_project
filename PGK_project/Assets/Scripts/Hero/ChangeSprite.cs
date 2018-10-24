using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{

    private string spriteWeapon = "hero_weapon";
    private string spriteKnife = "hero2";
    private SpriteRenderer spriteR;
    private bool isChange;
    private float change_freeze = 0.3f;
    private float timer;
    private CircleCollider2D collider;
    private float circleColliderRadius;
    private Animator anim;

    void Start()
    {
        isChange = true;
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        timer = Time.time;
        collider = this.gameObject.GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        circleColliderRadius = collider.radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < Time.time)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (isChange)
                {
                    anim.enabled = false;
                    spriteR.sprite = Resources.Load<Sprite>(spriteKnife);
                    isChange = false;
                    this.GetComponent<Hero>().canShoot = false;
                    collider.offset = new Vector2(-0.23f, -2.85f);
                    collider.radius = 5.61f;

                }
                else
                {
                    anim.enabled = true;
                    spriteR.sprite = Resources.Load<Sprite>(spriteWeapon);
                    isChange = true;
                    this.GetComponent<Hero>().canShoot = true;
                    collider.offset = new Vector2(-1.065205f, -7.344338f);
                    collider.radius = circleColliderRadius;
                }
            }

            timer = Time.time + change_freeze;
        }
    }
}
    
