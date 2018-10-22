using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour {

    private string spriteWeapon = "hero_weapon";
    private string spriteHero = "hero_knife";
    private SpriteRenderer spriteR;
    private bool isChange;
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            if (isChange)
            {
                spriteR.sprite = Resources.Load<Sprite>(spriteWeapon);
                isChange = false;
            }
            if (!isChange)
            {
                spriteR.sprite = Resources.Load<Sprite>(spriteHero);
                isChange = true;
            }
        }
    }
}
