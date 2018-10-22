using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{


    public int zycie;
    public int atak;
    public float speed;
    public float czas_ataku;
    public int bron;
    public float time;
    public Vector3 spawn;
    GameObject player;
    Rigidbody2D wrog;
    Transform fire_point;
    public GameObject bullet;
    public bool statyczny;
    private float time_tracker_strzalu;
    private float time_tracker_gonga;
    bool w_zasiegu_ataku_wrecz;
    public float czas_ataku_wrecz;
    public float zasieg;


    void Start()
    {

        player = GameObject.FindWithTag("Player");
        wrog = this.GetComponent<Rigidbody2D>();
        time = Time.time;
        spawn = this.transform.position;
        if (this.transform.Find("FirePoint"))
            fire_point = this.transform.Find("FirePoint");
        time_tracker_strzalu = Time.time;
        w_zasiegu_ataku_wrecz = false;
        time_tracker_gonga = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        sprawdz_czy_umarl();

        if (znaleziono_gracza())
        {
            obroc_do_playera();
            if (statyczny)
            {
                if (time_tracker_strzalu < Time.time)
                {
                    strzel();
                    time_tracker_strzalu = Time.time + czas_ataku;
                }
            }
            else
            {
                porusz_w_strone_gracza();
                if (time_tracker_gonga < Time.time)
                {
                    if (atak_wrecz())
                        time_tracker_gonga = Time.time + czas_ataku_wrecz;
                }
            }
        }
        else
        {
            wracaj_na_sapwn();
        }
    }

    void wracaj_na_sapwn()
    {
        Vector3 elo = spawn - this.transform.position;
        if (elo.magnitude > 0.1f)
            this.transform.position += kierunek(elo) * Time.deltaTime * speed;
    }
    void porusz_w_strone_gracza()
    {
        Vector3 elo = player.transform.position - this.transform.position;
        this.transform.position += kierunek(elo) * Time.deltaTime * speed;
    }

    Vector3 kierunek(Vector3 zycie)
    {
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
        return new Vector3(x, y, 0f);
    }



    bool znaleziono_gracza()
    {
        Vector2 pozycja_gracza = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 przesuniecie = pozycja_gracza - new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D trafienie = Physics2D.Raycast(transform.position, przesuniecie, zasieg);
        if (trafienie.collider.tag == "Player")
            return true;
        else
            return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            zycie -= 1;
        }
    }

    void sprawdz_czy_umarl()
    {
        Debug.Log("zycie " + zycie);
        if (this.zycie < 0)
            Destroy(this.gameObject);
    }

    void strzel()
    {
        Instantiate(bullet, fire_point.position, fire_point.rotation);
    }

    bool atak_wrecz()
    {
        Vector2 pozycja_gracza = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 przesuniecie = pozycja_gracza - new Vector2(transform.position.x, transform.position.y);
        if (przesuniecie.magnitude < 1f)
        { //odleglosc do ataku

            player.GetComponent<Hero>().health--;
            return true;
        }
        return false;

    }

    void obroc_do_playera()
    {
        Vector2 gracz = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 enemy = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 result = new Vector2(gracz.x - enemy.x, gracz.y - enemy.y);
        // if(Vector2.SignedAngle(result, Vector2.up) > 5f)
        // this.transform.Rotate(new Vector3(0f, 0f, Vector2.SignedAngle(result, Vector2.up)));
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -1 * Vector2.SignedAngle(result, Vector2.up)));

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            w_zasiegu_ataku_wrecz = true;


    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            w_zasiegu_ataku_wrecz = false;
    }
}
