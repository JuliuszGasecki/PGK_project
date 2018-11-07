using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAndAdd : MonoBehaviour {

    private float angle = 0;
    private Hero hero;

    private IWeapon weapon;

    private Inventory inv;    
    // Use this for initialization
    void Start ()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        weapon = GameObject.Find("Inventory").GetComponent<DEAGLE>();
    }
	
	// Update is called once per frame
	void Update ()
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
            if (Input.GetKeyDown(KeyCode.K))
            {
                inv.GetInventory().Add(weapon);
                destroyObject();
            }
        }


    }

    private void destroyObject()
    {
        Destroy(gameObject);
    }
}
