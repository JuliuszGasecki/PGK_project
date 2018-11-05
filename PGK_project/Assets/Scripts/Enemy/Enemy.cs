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
    private Vector3 spawn;
    private Vector3 rotacja_orginalna;
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
    public float czas_na_powrot;
    private float time_tracker_powrotu;
    public int rate_ganja; // 1-100
    public int rate_extasy;
    public GameObject ganja; 
    public GameObject extasy;
    public GameObject coca;
    private List<Vector3> punkty_powrotne;
    private float czas_pomiedzy_punktami;


    void zrob_punkt(Vector3 miejsce){
        punkty_powrotne.Add(miejsce);
    }
    void usun_ostatni(){
        if(punkty_powrotne.Count >=1)
            punkty_powrotne.RemoveAt(punkty_powrotne.Count - 1);
    }

    void wracaj_po_punkcie(){
        if (punkty_powrotne.Count > 0)
        {
            Vector3 last_point = punkty_powrotne[punkty_powrotne.Count - 1];

            Vector3 wypadkowy_wektor = last_point - this.transform.position;
            if (wypadkowy_wektor.magnitude > 0.1f)
            {
                this.transform.position += kierunek(wypadkowy_wektor) * Time.deltaTime * speed;
            }
            else
                usun_ostatni();
        }
        else
            wracaj_na_spawn();
    }


    void Start()
    {
        rotacja_orginalna = transform.rotation.eulerAngles;
        punkty_powrotne = new List<Vector3>();
        czas_pomiedzy_punktami = 0.2f;
        if(GameObject.FindWithTag("Player"))
            player = GameObject.FindWithTag("Player");
        wrog = this.GetComponent<Rigidbody2D>();
        time = Time.time;
        spawn = this.transform.position;
        if (this.transform.Find("FirePoint"))
            fire_point = this.transform.Find("FirePoint");
        time_tracker_strzalu = Time.time;
        w_zasiegu_ataku_wrecz = false;
        time_tracker_gonga = Time.time;
        time_tracker_powrotu = Time.time;
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
                if (time_tracker_powrotu < Time.time)
                {
                    Debug.Log("cooo");
                    zrob_punkt(transform.position);
                    time_tracker_powrotu = Time.time + czas_na_powrot;
                    Debug.Log(punkty_powrotne.Count);
                }
                if (time_tracker_gonga < Time.time)
                {
                    if (atak_wrecz())
                        time_tracker_gonga = Time.time + czas_ataku_wrecz;
                }
            }
        }
        else
        {
            if (time_tracker_powrotu + czas_na_powrot < Time.time)
                wracaj_po_punkcie();

        }
    }

    void odbij_od_sciany()
    {

                   
              
    }
    void wracaj_na_spawn()
    {
        Vector3 elo = spawn - this.transform.position;
        if (elo.magnitude > 0.1f)
            this.transform.position += kierunek(elo) * Time.deltaTime * speed;
        else
            this.transform.rotation = Quaternion.Euler(rotacja_orginalna);
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
        if (trafienie.collider != null)
        {
            if (trafienie.collider.gameObject.tag == "Player")
                return true;
            else
                return false;
        }
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
        {
            if (Random.Range(0f,4f) > 3)
                Instantiate(ganja, transform.position, transform.rotation);
            if (Random.Range(0f, 4f) > 3)
                    Instantiate(extasy, transform.position, transform.rotation);
            if (Random.Range(0f, 6f) > 5)
                    Instantiate(coca, transform.position, transform.rotation);
            ScoreCounter.scoreValue += 21;


            Destroy(this.gameObject);
        }
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
