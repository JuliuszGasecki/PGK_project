using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Hero hero;
    private GameObject knife;
    private bool canShoot;
    // Use this for initialization
    void Start()
    {
        knife = GameObject.Find("knife");
        canShoot = hero.canShoot;
        Debug.Log(canShoot);
        knife.SetActive(false);
    }

    void Attack()
    {
        Debug.Log(canShoot);
        if (canShoot == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                knife.SetActive(true);
            }
        }
        else
        {
            knife.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        canShoot = hero.canShoot;
        Debug.Log(canShoot);
        Attack();
    }

}
