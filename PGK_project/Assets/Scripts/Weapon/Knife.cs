using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private float _timeBtwAttack = 0;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public int damage;
    private Inventory _inventory;
    private Animator heroAnim;

    private bool CanAttack;

    private bool CanDoDmg;
    private bool CanPlayAnim;
    private float AnimationTime;

    private float time;
    // Use this for initialization
    void Start()
    {
        _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        heroAnim = GameObject.Find("Hero").GetComponent<Animator>();
        AnimationTime = Time.time;
    }

    void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("LPM");
            CanPlayAnim = true;
            time = Time.time;
        }
    }

    private void PlayAnimation()
    {
        if (CanPlayAnim)
        {
            heroAnim.SetBool("isKnifeAttack", true);
            CanDoDmg = true;
            CanPlayAnim = false;
        }
        else if (Time.time - time >= 0.25 && !CanPlayAnim)
        {
            heroAnim.SetBool("isKnifeAttack", false);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            _inventory.VModeUser = !_inventory.VModeUser;
            heroAnim.SetBool("isKnife", _inventory.VModeUser);
            CanAttack = true;
        }
        if (_inventory.VMode)
        {
            heroAnim.SetBool("isKnife", true);
            CanAttack = true;
        }
        if (!_inventory.VMode && !_inventory.VModeUser)
        {
            heroAnim.SetBool("isKnife", false);
            CanAttack = false;
        }
        if (CanAttack)
        {
            if (_timeBtwAttack <= 0)
            {
                Attack();
                _timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                _timeBtwAttack -= Time.deltaTime;
            }
        }
        PlayAnimation();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var tag = collision.gameObject.tag;
        if (tag == "Enemy" && CanDoDmg)
        {
            collision.gameObject.GetComponent<Enemy2>().life -= damage;
            Debug.Log("ATTACk");
            CanDoDmg = false;
            //CanAttack = false;
            //heroAnim.SetBool("isKnifeAttack", CanAttack);
        }
    }
}