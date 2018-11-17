using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private string name;
    public GameObject Weapon;
    private bool CanOpen;
    private GameObject _myItem;
    private Vector2 start;
    private Vector2 endPoint;
    private Vector2 middlePoint;
    private float count = 0.0f;
    private float speed = 2.0f;
    private float newX = -1.0f;
    private float newY = 0.0f;
    private float height = 2.0f;
    private SpriteRenderer spriteR;
    private string ClosedChestSprite = "Chest/openedChest";
    private bool IsEmpty;
    // Use this for initialization
    void Start()
    {
        name = this.gameObject.name;
        start = new Vector2(this.transform.position.x, this.transform.position.y);
        endPoint = new Vector2(start.x + newX, start.y + newY);
        middlePoint = start + (endPoint - start) / 2 + Vector2.up * height;
        spriteR = gameObject.GetComponent<SpriteRenderer>();      
    }

    // Update is called once per frame
    void Update()
    {
        if (_myItem != null)
        {
            if (count < 1.0f)
            {
                spriteR.sprite = Resources.Load<Sprite>(ClosedChestSprite);
                count += speed * Time.deltaTime;
                Vector2 m1 = Vector2.Lerp(start, middlePoint, count);
                Vector2 m2 = Vector2.Lerp(middlePoint, endPoint, count);
                _myItem.transform.position = Vector2.Lerp(m1, m2, count);
            }
        }
    }


    void OnMouseDown()
    {
        if (CanOpen && !IsEmpty)
        {
            
            IsEmpty = true;
            _myItem = Instantiate(Weapon, this.transform.position, Quaternion.identity) as GameObject;
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
