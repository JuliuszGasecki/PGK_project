using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFloors : MonoBehaviour {

    public GameObject destination;
    public GameObject to;
    public GameObject from;
    private Transform hero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Dupsko wielkie");
            hero = GameObject.Find("Hero").GetComponent<Transform>();
            hero.transform.position = destination.transform.position;
            to.SetActive(true);
            from.SetActive(false);
        }
    }
}
