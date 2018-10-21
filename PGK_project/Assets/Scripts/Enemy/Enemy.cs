using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour {


    public int zycie;
    public int atak;
    public float speed = 5f;
    public float czas_ataku;
    public int bron;
    public float time = 0;
    public Vector3 spawn;
    GameObject player;
    Rigidbody2D wrog;

    // Use this for initialization
    void Start () {

        player = GameObject.FindWithTag("Player");
        wrog = this.GetComponent<Rigidbody2D>();
        time = Time.time;
        spawn = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(tag_trafienia()){
            porusz_w_strone_gracza();
        }
        else{
            wracaj_na_sapwn();
        }
    }

    void wracaj_na_sapwn(){
        Vector3 elo = spawn - this.transform.position;
        if (elo.magnitude > 0.1f)
            this.transform.position += kierunek(elo) * Time.deltaTime * speed;
       }
    void porusz_w_strone_gracza(){
        Vector3 elo = player.transform.position - this.transform.position;
        this.transform.position += kierunek(elo) * Time.deltaTime *speed;
    }

    Vector3 kierunek(Vector3 zycie){
        float x = zycie.x;
        float y = zycie.y;
        if (Mathf.Abs(x) >= Mathf.Abs(y))
        {
            y = y / Mathf.Abs(x);
            x = x / Mathf.Abs(x);

        }
        else if (Mathf.Abs(x) < Mathf.Abs(y))
        {
            x = x / Mathf.Abs(y);
            y = y / Mathf.Abs(y);
        }
        return new Vector3(x, y,0f);
    }



    bool tag_trafienia(){
        Vector2 pozycja_gracza = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 przesuniecie = pozycja_gracza - new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D trafienie = Physics2D.Raycast(transform.position,przesuniecie);
        if (trafienie.collider.tag == "Player")
        {
            Debug.Log("eloo");
            return true;
        }
        else
        {
            Debug.Log("niee");
            return false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"){

        }
        if (collision.gameObject.tag == "Bullet")
        {

        }
    }
}
