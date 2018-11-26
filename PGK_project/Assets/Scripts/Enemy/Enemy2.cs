using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using Pathfinding;

public class Enemy2 : MonoBehaviour {

    //***** zmienne ogol

    private bool alive;
    public int life;
    public int attack;
    public float speed;
    public float time_of_attack_punch;
    public int weapon_number;

    //*****

    //***** przypisywanko

    public GameObject bullet;
    public Sprite dead_enemy;
    public GameObject weapon;
    private Animator anim;
    private Vector3 spawn;
    private Quaternion spawn_rotation;
    private GameObject player;
    private Rigidbody2D enemy;
    private Transform fire_point;

    //*****

    //***** zmienne atak

    public bool isStatic;
    public float time_beetwen_punch_attack;
    public float range_of_enemy;
    public float shoot_time;
    private float time_tracker_shoot;
    private float time_tracker_punch;
    private bool in_range_of_punch_attack;
    public float time_to_come_back_to_path;
    private float time_tracker_come_back_to_path;
    public float speed_boost_when_low_hp;
    public int speed_boost_limit;


    //*****

    //***** narkotyki

    public int rate_ganja; // 1-100
    public int rate_extasy;
    public GameObject ganja;
    public GameObject extasy;
    public GameObject coca;

    //*****

    //***** znajdywanie drogi

    private AIDestinationSetter aItarget;
    private AIPath aIPath;
    private GameObject guide;
    public GameObject publicGuide;

    //******

    public bool generate_path;
    public float length_of_the_path;
    public int number_of_break_points;
    public List<Vector3> path;

    private Vector3 last_seen_player;

    void speed_boost(){
        if(life < speed_boost_limit)
        {
            this.speed += speed_boost_limit;
        }
    }

    bool generate_the_path(int number_of_tries){
        if (length_of_the_path < 1 || number_of_break_points < 1)
        {
            return false;
        }
        else
        {
            path.Add(this.transform.position);
            int number_of_try = number_of_tries;
            int numPoints = number_of_break_points;
            float path_length = length_of_the_path / number_of_break_points;
            while (numPoints > 0 && number_of_try > 0){
                number_of_try--;
                Vector3 new_point = generateRandomVector3(path_length);
                if(check_if_point_is_correct(new_point, path[path.Count - 1], path_length))
                {
                    path.Add(new_point);
                    number_of_try = number_of_break_points;
                }
                Debug.Log(number_of_try);
            }
            if (numPoints < 0)
                return false;
            else
                return true;
        }
    }

    Vector3 generateRandomVector3(float magnitude){
        Vector2 temp = Random.insideUnitCircle * 10;
        temp = temp.normalized;
        return new Vector3(temp.x, temp.y, 0) * magnitude;
    }

    bool check_if_point_is_correct(Vector3 new_point, Vector3 old_point,float magnitude){
        RaycastHit2D ray = Physics2D.Raycast(old_point, new_point, magnitude + 0.1f);
        if (ray.collider != null)
        {
            Debug.Log(ray.collider.ToString());
            return false;
        }
        else
            return true;
    }

    void Start()
    {
        if (generate_the_path(200))
            Debug.Log("jest sciezka");
        if (GameObject.FindWithTag("Player")) { player = GameObject.FindWithTag("Player"); }
        if (this.transform.Find("FirePoint")) { fire_point = this.transform.Find("FirePoint"); }
        enemy = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        aItarget = this.GetComponent<AIDestinationSetter>();
        aIPath = this.GetComponent<AIPath>();
        aItarget.target = null;

        spawn = this.transform.position;
        spawn_rotation = this.transform.rotation;
        alive = true;
        in_range_of_punch_attack = false;

        time_tracker_shoot = Time.time;
        time_tracker_punch = Time.time;
        time_tracker_come_back_to_path = Time.time;

        last_seen_player = spawn;

        guide = Instantiate(new GameObject(), spawn, spawn_rotation);
        if (guide != null)
        {
            aItarget.target = guide.transform;
        }
        aIPath.maxSpeed = this.speed;
        time_tracker_shoot = Time.time;
        generate_the_path(50);
        time_tracker_punch = Time.time;
    }


    void Update()
    {
        if (alive)
        {
            if (!sprawdz_czy_umarl())
            {
                speed_boost();
                if (!isStatic)
                {

                    if (znaleziono_gracza())
                    {
                        guide.transform.position = player.transform.position;
                        obroc_do_playera();
                        atak_wrecz();
                        anim.SetBool("isWalking", true);

                    }
                    else
                    {
                        guide.transform.position = last_seen_player;
                        Debug.Log(last_seen_player.ToString());
                        if (this.transform.position == last_seen_player)
                        {
                            last_seen_player = spawn;
                            guide.transform.rotation = spawn_rotation;
                        }
                        anim.SetBool("isWalking", false);
                    }
                }
                else
                {
                    if (znaleziono_gracza())
                    {
                        obroc_do_playera();
                        if (Time.time - time_tracker_shoot > shoot_time)
                        {
                            strzel();
                            time_tracker_shoot = Time.time;
                        }
                    }
                }
            }
        }

    }




    bool znaleziono_gracza()
    {
        Vector2 pozycja_gracza = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 przesuniecie = pozycja_gracza - new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D trafienie = Physics2D.Raycast(transform.position, przesuniecie, range_of_enemy);
        if (trafienie.collider != null)
        {
            if (trafienie.collider.gameObject.tag == "Player")
            {
                last_seen_player = trafienie.collider.gameObject.transform.position;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
            return false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            in_range_of_punch_attack = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            in_range_of_punch_attack = true;

        }
        if (collision.gameObject.tag == "Bullet")
        {
            life -= 1;
            last_seen_player = player.transform.position;
            if (life < 0)
            {
                aIPath.canMove = false;
                sprawdz_czy_umarl();
            }

        }
    }

    bool sprawdz_czy_umarl()
    {
        if (this.life < 0 && alive == true)
        {
            aIPath.canMove = false;
            wypadanie_broni();
            wypadanie_narkotykow();
            ScoreCounter.scoreValue += 21;
            KilledStat.killedValue += 1;
            this.GetComponent<SpriteRenderer>().sprite = dead_enemy;
            this.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<Transform>().localScale = new Vector3(0.35f, 0.35f, 1f);
            alive = false;
            anim.enabled = false;
            return true;
        }
        else
            return false;
    }

    public void wypadanie_broni()
    {
        float x = Random.Range(-0.2f, 0.2f);
        float y = Random.Range(-0.2f, 0.2f);
        Vector3 placment_bron = new Vector3(0f + x, 0f + y, 0f);
        if (weapon != null)
            Instantiate(weapon, transform.position + placment_bron, transform.rotation);
    }
    public void wypadanie_narkotykow()
    {
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

    void atak_wrecz()
    {
        if (in_range_of_punch_attack && Time.time - time_tracker_punch > time_of_attack_punch)
        { 

            player.GetComponent<Hero>().health--;
            time_tracker_punch = Time.time;
        }
       


    }



    void obroc_do_playera()
    {
        Vector2 gracz = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 wrog = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 result = new Vector2(gracz.x - wrog.x, gracz.y - wrog.y);
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -1 * Vector2.SignedAngle(result, Vector2.up)));

    }

}
