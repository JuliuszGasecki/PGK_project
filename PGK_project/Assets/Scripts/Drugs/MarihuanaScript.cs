using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarihuanaScript : MonoBehaviour {
    DrugsTimer hero;
    private float angle = 0;
    private bool playerOnTarget = false;
    float time = 0;

    // Use this for initialization
    void Start()
    {

    }

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    /*void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }*/

    // Update is called once per frame
    void Update()
    {
        bounce();
        if (time < 0)
        {
            playerOnTarget = false;
            time = 0;
        }
        if (playerOnTarget == true && time >= 0)
        {
            time -= Time.fixedDeltaTime;
        }
        if (playerOnTarget == true && Input.GetMouseButton(1) || Input.GetKeyDown(KeyCode.E))
        {
            hero.marihuanaTime += 50;
            destroyObject();
            //OnMouseExit();
        }
    }

    private void bounce()
    {
        float lastY = transform.position.y;
        transform.position = new Vector3(transform.position.x, lastY + Mathf.Sin(angle) / 80, transform.position.z);
        angle += 3.14f / 64f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hero = other.gameObject.GetComponent<DrugsTimer>();
            playerOnTarget = true;
            time += 1;
        }
        else
            playerOnTarget = false;
    }



    private void destroyObject()
    {
        Destroy(gameObject);
    }
}
