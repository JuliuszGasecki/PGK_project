using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugTemplate : MonoBehaviour {

    public string nazwa;
    Hero hero;
    DrugsTimer heroDrugTimer;
    private float angle = 0;
    float time = 0;
    public float speedBoost;
    public float lifeBoost;
    public float attackBoost;
    float timeofuse;


    public void setTimeOfUse(float time){
        timeofuse = time;
    }
    public void getTimeOfUse(float time)
    {
        return timeofuse;
    }

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bounce();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            hero = collision.GetComponent<Hero>();
            heroDrugTimer = collision.GetComponent<DrugsTimer>();
        }

    }


    private void bounce()
    {
        float lastY = transform.position.y;
        transform.position = new Vector3(transform.position.x, lastY + Mathf.Sin(angle) / 80, transform.position.z);
        angle += 3.14f / 64f;
    }

    void destroyObject()
    {
        Destroy(gameObject);
    }
}
