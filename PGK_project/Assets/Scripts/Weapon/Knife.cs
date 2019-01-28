using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private float _timeBtwAttack = 0;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public int damage;
    private Inventory _inventory;

    private bool CanAttack;
    // Use this for initialization
    void Start()
    {
        _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    void Attack()
    {
        if (_inventory.GetInventory().Count == 0)
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("wtf222");
                CanAttack = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
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
    void OnTriggerEnter2D(Collider2D collision)
    {

        var tag = collision.gameObject.tag;
        if (tag == "Enemy" && CanAttack)
        {
            collision.gameObject.GetComponent<Enemy2>().life -= damage;
            Debug.Log("wtf");
            CanAttack = false;
        }

    }


}
