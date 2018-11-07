using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAndAdd : MonoBehaviour {

    private float angle = 0;
    private Hero hero;

    private DEAGLE deagle;

    private Inventory inv;    
    // Use this for initialization
    void Start ()
    {
        inv = GameObject.Find("Hero").GetComponent<Inventory>();
        deagle = this.gameObject.GetComponent<DEAGLE>();
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
            hero = collision.GetComponent<Hero>();
            deagle = collision.GetComponent<DEAGLE>();
            if (Input.GetKeyDown(KeyCode.K))
            {
                inv.AddToList(deagle);
                destroyObject();
            }
        }


    }

    private void destroyObject()
    {
        Destroy(gameObject);
    }
}
