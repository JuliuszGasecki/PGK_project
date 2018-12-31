using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AddSpecialWeapon : MonoBehaviour
{

    private float angle = 0;
    private Hero hero;

    private ISpecialWeapon weapon;
    private bool _isSpecial;
    private Inventory inv;

    private string[] _weaponNames = { "CROSSBOW" };


    private string nameW;
    // Use this for initialization
    void Start()
    {
        _isSpecial = true;
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        var downloadStrings = this.gameObject.name.Split(new[] { '(' }, 2);
        nameW = downloadStrings[0];
        nameW = nameW.Replace(" ", string.Empty);
        if (_weaponNames.Contains(nameW))
        {
            weapon = GameObject.Find("Inventory").GetComponent(nameW) as ISpecialWeapon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bounce();
    }

    private void bounce()
    {
        float lastY = transform.position.y;
        transform.position = new Vector3(transform.position.x, lastY + Mathf.Sin(angle) / 80, transform.position.z);
        angle += 3.14f / 64f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && _isSpecial)
            {
                inv.AddSpecialWeapon(weapon);
                destroyObject();
                GameObject.Find("SpecialWeaponTutorialManager").GetComponent<SpecialWeaponsTutorial>().IsActive = true;
            }

        }
    }

    

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && _isAmmo)
        {
            Debug.Log("xDDDDDDDDDD");
            AddAmmo();
            destroyObject();
        }
    }*/

    private void destroyObject()
    {
        Destroy(gameObject);
    }
}
