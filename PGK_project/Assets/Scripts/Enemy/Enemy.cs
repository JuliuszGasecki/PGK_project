using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    int stateHUNT = 0;
    int statePATH = 1;
    int currentState;
    bool go_forwad; // to jest po to ze jak masz sciezke 123 to zeby wracal 321
    public List<Transform> pathPoints;
    int targetpathPoint;
    bool alive;
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
    public Sprite dead_enemy;
    public GameObject weapon;
    private Animator anim;


    void Start()
    {
       // anim = GetComponent<Animator>();
        go_forwad = true;
        currentState = statePATH;
        targetpathPoint = 0;
        // pathPoints = new List<Transform>();
        alive = true;
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
        if (alive)
        {
            sprawdz_czy_umarl();

                if (znaleziono_gracza())
                {

                    //anim.SetBool("isWalking", true);
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

                            zrob_punkt(transform.position);
                            time_tracker_powrotu = Time.time + czas_na_powrot;

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
                    //anim.SetBool("isWalking", false);
                    if (time_tracker_powrotu + czas_na_powrot < Time.time)
                {
                    if(punkty_powrotne.Count > 1)
                         wracaj_po_punkcie();
                    else
                        chodzenie_po_sciezce();
                }
            }


            

        }
    }

    void chodzenie_po_sciezce(){
        if (pathPoints.Count > 0){
            Vector3 droga = pathPoints[targetpathPoint].position - gameObject.transform.position;
            if (droga.magnitude < 1f)
            {
                if (go_forwad)
                    targetpathPoint++;
                else
                    targetpathPoint--;
                if(targetpathPoint < 0){
                    targetpathPoint = 1;
                    go_forwad = true;
                }
                if (targetpathPoint > pathPoints.Count - 1)
                {
                    targetpathPoint = pathPoints.Count - 2;
                    go_forwad = false;
                }
            }
            gameObject.transform.position += new Vector3(droga.normalized.x,droga.normalized.y,0f) * Time.deltaTime * speed/2;
        }
    }

    void zrob_punkt(Vector3 miejsce)
    {
        punkty_powrotne.Add(miejsce);
    }
    void usun_ostatni()
    {
        if (punkty_powrotne.Count >= 1)
            punkty_powrotne.RemoveAt(punkty_powrotne.Count - 1);
    }

    void wracaj_po_punkcie()
    {
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


    void wracaj_na_spawn()
    {
        Vector3 elo = spawn - this.transform.position;
        if (elo.magnitude > 0.1f)
        {
            this.transform.position += kierunek(elo) * Time.deltaTime * speed;
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(rotacja_orginalna);
            currentState = statePATH;
        }
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
        if (this.zycie < 0 && alive == true)
        {
            wypadanie_broni();
            wypadanie_narkotykow();
            ScoreCounter.scoreValue += 21;
            KilledStat.killedValue += 1;

            this.GetComponent<SpriteRenderer>().sprite = dead_enemy;
            this.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<Transform>().localScale = new Vector3(0.35f, 0.35f, 1f);
            alive = false;
            //Destroy(this.gameObject);
        }
    }

    public void wypadanie_broni()
    {
       float x = Random.Range(-0.2f, 0.2f);
        float y = Random.Range(-0.2f, 0.2f);
        Vector3 placment_bron = new Vector3(0f + x , 0f + y, 0f);
        if(weapon != null)
            Instantiate(weapon, transform.position  + placment_bron, transform.rotation);
    }
        public void wypadanie_narkotykow(){
        bool wypadl_narkotyk = false;
        if (Random.Range(0f, 4f) > 3 && wypadl_narkotyk == false)
        {
            Instantiate(ganja, transform.position, transform.rotation);
            wypadl_narkotyk = true;
        }
        if (Random.Range(0f, 4f) < 1 && wypadl_narkotyk == false)
        {
            Instantiate(extasy, transform.position, transform.rotation);
            wypadl_narkotyk = true;
        }
        if (Random.Range(0f, 6f) > 5 && wypadl_narkotyk == false)
        {
            Instantiate(coca, transform.position, transform.rotation);
            wypadl_narkotyk = true;
        }
    }

    void strzel()
    {
        GameObject bulletE = Instantiate(bullet, fire_point.position, fire_point.rotation);
        bulletE.GetComponent<Bullet>().bulletDamage = 2;
        bulletE.GetComponent<Bullet>().bulletSpeed = 20f;
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
