using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private new string _name;
    public GameObject Weapon;
    private bool CanOpen;
    private GameObject _myItem;
    private Vector3 start;
    private Vector3 endPoint;
    private Vector3 middlePoint;
    private float count = 0.0f;
    private float speed = 2.0f;
    private float newX = -2.0f;
    private float newY = 0.0f;
    private float height = 2.5f;
    private SpriteRenderer spriteR;
    private float timeUntilDisableTrail = 0;
    private string OpenedChestSprite = "Chest/openedChest";
    private bool IsEmpty;
    // Use this for initialization
    void Start()
    {
        _name = this.gameObject.name;
        start = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        endPoint = new Vector3(start.x + newX, start.y + newY, this.transform.position.z);
        middlePoint = start + (endPoint - start) / 2 + Vector3.up * height;
        spriteR = gameObject.GetComponent<SpriteRenderer>();      
    }

    // Update is called once per frame
    void Update()
    {
        if (_myItem != null)
        {
            if (count < 1.0f)
            {
                spriteR.sprite = Resources.Load<Sprite>(OpenedChestSprite);
                count += speed * Time.deltaTime;
                Vector3 m1 = Vector3.Lerp(start, middlePoint, count);
                Vector3 m2 = Vector3.Lerp(middlePoint, endPoint, count);
                _myItem.transform.position = Vector3.Lerp(m1, m2, count);
                timeUntilDisableTrail = Time.time + 0.5f;
            }
            else if (Time.time > timeUntilDisableTrail)
            {
                _myItem.GetComponent<TrailRenderer>().enabled = false;
            }
        }
    }


    void OnMouseOver()
    {
        if (Input.GetMouseButton(1) && CanOpen && !IsEmpty)
        {         
            IsEmpty = true;
            _myItem = Instantiate(Weapon, this.transform.position, Quaternion.identity) as GameObject;
            _myItem.GetComponent<TrailRenderer>().enabled = true;
            // item.transform.position += new Vector3(-0.2f, 0.2f, 0.0f);

        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanOpen = true;
            GameObject.Find("Inventory").GetComponent<Inventory>().GetUsingWeapon().CanUse = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanOpen = false;
            GameObject.Find("Inventory").GetComponent<Inventory>().GetUsingWeapon().CanUse = true;
        }

    }
}
