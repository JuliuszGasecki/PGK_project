using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using Pathfinding;
using Random = UnityEngine.Random;

public class Enemy2 : MonoBehaviour
{
    //***** zmienne ogol
    public bool show_rotation;

    public bool alive;
    public int life;
    public int attack;
    public int punch_attack;
    public float speed;
    public float time_of_attack_punch;
    public int weapon_number;
    public int beast_mode_barrier;

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
    public int random_multiplayer;


    //*****

    //***** narkotyki

    public int rate_ganja; // 1-100
    public int rate_extasy;
    public GameObject ganja;
    public GameObject extasy;
    public GameObject coca;
    public GameObject lsd;
    public GameObject mocarz;
    public GameObject vodka;

    //*****

    //***** znajdywanie drogi

    private AIDestinationSetter aItarget;
    private AIPath aIPath;
    private GameObject guide;


    //******

    public bool generate_path;
    public float length_of_the_path;
    public int number_of_break_points;
    public List<Vector3> path;
    private int indexOfCurrentPath;

    private Vector3 last_seen_player;

    private float avoid_bullets_timer;
    public float avoid_bullets_time;
    private Vector3 avoid_bullets_movement;
    public float sensivity_of_enemys;

    DrugsTimer hero;

    //***** specjalny efekt z specjalnych broni dla specjalnych ludzi specjalnie od specjalnego Stempnia moje wy specjały :*
    private List<Action> AmazingEffectFunctions;
    public GameObject M4;

    void print_angle(Vector3 point)
    {
    }

    int give_the_closest_point_on_the_path()
    {
        int index = 0;
        Vector3 pathPoint = new Vector3(0, 0, 0);
        float magnitude = 999999;
        for (int i = 0; i < path.Count; i++)
        {
            Vector3 nan = this.transform.position - path[i];
            if (magnitude > nan.magnitude)
            {
                index = i;
                pathPoint = path[i];
            }
        }

        return index;
    }

    void go_along_path()
    {
        guide.transform.position = path[indexOfCurrentPath];
        Vector3 distance = this.transform.position - path[indexOfCurrentPath];
        if (distance.magnitude < 0.5f)
        {
            indexOfCurrentPath = indexOfCurrentPath % path.Count;
        }
    }

    void avoid_bullets(float distance, ref Vector3 direction)
    {
        //avoid bullets
        obroc_do_playera();

        Vector3 left = this.transform.position - player.transform.position;
        Vector3 right = this.transform.position - player.transform.position;
        left.x = left.x * -1f;
        right.y = right.y * -1f;
        Vector2 random2 = Random.insideUnitSphere;
        Vector3 random_multplayer = new Vector3(random2.x, random2.y, 0f);
        if (Random.value > 0.5f)
        {
            if (check_if_we_can_move_to_direction((left.normalized + random_multplayer) * distance, distance))
            {
                direction = (left.normalized + random_multplayer) * distance * Time.deltaTime;
            }
            else
            {
                if ((check_if_we_can_move_to_direction((right.normalized + random_multplayer) * distance, distance)))
                {
                    direction = (right.normalized + random_multplayer) * distance * Time.deltaTime;
                }
            }
        }
        else
        {
            if (check_if_we_can_move_to_direction((right.normalized + random_multplayer) * distance, distance))
            {
                direction = (right.normalized + random_multplayer) * distance * Time.deltaTime;
            }
            else
            {
                if (check_if_we_can_move_to_direction((left.normalized + random_multplayer) * distance, distance))
                {
                    direction = (left.normalized + random_multplayer) * distance * Time.deltaTime;
                }
            }
        }
    }

    bool check_if_we_can_move_to_direction(Vector3 new_position, float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, new_position, distance);
        if (hit.collider != null)
        {
//            Debug.Log(hit.collider.tag);
            return false;
        }
        else
            return true;
    }


    void speed_boost()
    {
        if (life < speed_boost_limit)
        {
            this.speed += speed_boost_limit;
        }
    }

    bool generate_the_path(int number_of_tries)
    {
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
            while (numPoints > 0 && number_of_try > 0)
            {
                number_of_try--;
                Vector3 new_point = generateRandomVector3(path_length);
                if (check_if_point_is_correct(new_point, path[path.Count - 1], path_length))
                {
                    path.Add(new_point);
                    number_of_try = number_of_break_points;
                }

//                Debug.Log(number_of_try);
            }

            if (numPoints < 0)
                return false;
            else
                return true;
        }
    }

    Vector3 generateRandomVector3(float magnitude)
    {
        Vector2 temp = Random.insideUnitCircle * 10;
        temp = temp.normalized;
        return new Vector3(temp.x, temp.y, 0) * magnitude;
    }

    bool check_if_point_is_correct(Vector3 new_point, Vector3 old_point, float magnitude)
    {
        RaycastHit2D ray = Physics2D.Raycast(old_point, new_point, magnitude + 0.1f);
        if (ray.collider != null)
        {
//            Debug.Log(ray.collider.ToString());
            return false;
        }
        else
            return true;
    }

    void Start()
    {
        AmazingEffectFunctions = new List<Action>();
        FillAmazingEffectList();

        hero = GameObject.Find("Hero").GetComponent<DrugsTimer>();
        indexOfCurrentPath = 0;
        Random random = new Random();
        if (generate_the_path(200))
            //Debug.Log("jest sciezka");
            if (GameObject.FindWithTag("Player"))
            {
                player = GameObject.FindWithTag("Player");
            }

        if (this.transform.Find("FirePoint"))
        {
            fire_point = this.transform.Find("FirePoint");
        }

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
        avoid_bullets_timer = Time.time;
        if (isStatic)
            aItarget.target = null;
        avoid_bullets_movement = new Vector3(0, 0, 0);
    }


    void Update()
    {
        if (player == null){if (GameObject.FindWithTag("Player")) { player = GameObject.FindWithTag("Player"); }}
        else
        {
            //Debug.Log("player eoeoeoe");
        }
        if (bullet == null) { }//{Debug.Log(""); } else { Debug.Log("fuck"); }
       
        if (alive)
        {
            if (!sprawdz_czy_umarl())
            {
                speed_boost();
                if (!isStatic)
                {
                    if (znaleziono_gracza() || alert_mode())
                    {
                        Vector3 oddanie = this.transform.position - player.transform.position;
                        if (oddanie.magnitude > 1)
                        {
                            Vector2 random = Random.insideUnitSphere;
                            guide.transform.position = player.transform.position +
                                                       new Vector3(random.x, random.y, 0) * random_multiplayer;
                        }
                        else
                        {
                            guide.transform.position = player.transform.position;
                        }
                        //obroc_do_playera();

                        atak_wrecz();
                        anim.SetBool("isWalking", true);
                    }
                    else
                    {
                        //if (!alert_mode())
                        //{
                        guide.transform.position = last_seen_player;
                        //                        Debug.Log(last_seen_player.ToString());

                        if (this.transform.position == last_seen_player)
                        {
                            last_seen_player = spawn;
                            //guide.transform.rotation = spawn_rotation;
                        }

                        if (Vector3.Distance(this.transform.position, spawn) > 0.5)
                        {
                            obroc_do_punktu(last_seen_player);
                        }

                        anim.SetBool("isWalking", false);
                    }

                    //}
                }
                else
                {
                    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,
                        this.gameObject.transform.position.y, -1);
                    Vector2 upX = new Vector2(player.transform.up.x, player.transform.up.y);
                    Vector2 upC = new Vector2(this.transform.up.x, this.transform.up.y);

                    if (znaleziono_gracza())
                    {
                        if (Mathf.Abs(Vector2.SignedAngle(upC, upX)) > 90)
                        {
                            if (Time.time - avoid_bullets_timer > avoid_bullets_time)
                            {
                                avoid_bullets(sensivity_of_enemys, ref avoid_bullets_movement);
                                avoid_bullets_timer = Time.time;
                                avoid_bullets_movement.z = 0;
                            }


                            if (check_if_point_is_correct(this.transform.position,
                                this.transform.position + avoid_bullets_movement, sensivity_of_enemys))
                            {
                                avoid_bullets_movement.z = 0;
                                this.transform.position += avoid_bullets_movement;
                            }
                            else
                            {
                                avoid_bullets(sensivity_of_enemys, ref avoid_bullets_movement);
                                avoid_bullets_timer = Time.time;
                            }
                        }
                            if (Time.time - time_tracker_shoot - Random.Range(0f, 0.4f) > shoot_time)
                            {
                                strzel();
                                time_tracker_shoot = Time.time;
                            }
                        //}
                    }
                    else
                    {
                        //nie znaleziono playera wracaj na spawn
                        if (!alert_mode())
                        {
                            Vector3 path_to_spawn = spawn - this.transform.position;
                            if (path_to_spawn.magnitude < 0.5f)
                            {
                                aItarget.target = null;
                            }
                            else
                            {
                                guide.transform.position = spawn;
                                guide.transform.rotation = spawn_rotation;
                                aItarget.target = guide.transform;
                            }
                        }
                    }
                }
            }

            if (hero.lsdFlag == true)
            {
                anim.SetTrigger("activeLSD");
            }
            else if (hero.lsdFlag == false)
            {
                anim.SetTrigger("removeLSD");
            }
        }
    }


    bool alert_mode()
    {
        Vector2 pozycja_gracza = new Vector2(player.transform.position.x, player.transform.position.y);

        if (player.transform.Find("Inventory").GetComponent<Inventory>().isAlert() &&
            Vector2.Distance(pozycja_gracza, this.transform.position) < 20)
        {
            return true;
        }

        return false;
    }

    bool znaleziono_gracza()
    {
        Vector2 upC = new Vector2(this.transform.up.x, this.transform.up.y);
        Vector2 pozycja_gracza = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 przesuniecie = pozycja_gracza - new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D trafienie = Physics2D.Raycast(transform.position, przesuniecie, range_of_enemy);
        if (trafienie.collider != null)
        {
            if (trafienie.collider.gameObject.tag == "Player")
            {
                if (Mathf.Abs(Vector2.SignedAngle(upC, przesuniecie)) < (90 + Random.Range(0, 10)))
                {
                    obroc_do_playera();
                }

                if (player.transform.Find("Inventory").GetComponent<Inventory>().isAlert())
                {
                    if (Vector2.Distance(pozycja_gracza, this.transform.position) < 20)
                    {
                        obroc_do_playera();
                    }
                }

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
            beastMode();
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
            KilledStat.killedTimeList.Add(Time.time);
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

        if (Random.Range(0f, 6f) > 4 && wypadl_narkotyk == false)
        {
            Instantiate(mocarz, transform.position, transform.rotation);
            wypadl_narkotyk = true;
        }

        if (Random.Range(0f, 6f) > 3 && wypadl_narkotyk == false)
        {
            Instantiate(vodka, transform.position, transform.rotation);
            wypadl_narkotyk = true;
        }
    }

    void strzel()
    {
        if (bullet != null)
        {
            if (fire_point != null)
            {
                GameObject bulletE = Instantiate(bullet, fire_point.position, fire_point.rotation);

                if (bulletE != null)
                {
                    bulletE.GetComponent<Bullet>().bulletDamage = 2;
                    bulletE.GetComponent<Bullet>().bulletSpeed = 20f;
                }
                else{
                   // Debug.Log("fuckYY");
                }
            }
            else{
               // Debug.Log("fuckXX");
            }
        }
    }

    void beastMode()
    {
        if (life < beast_mode_barrier)
        {
            this.isStatic = false;
            this.speed *= 2;
        }
    }

    void atak_wrecz()
    {
        if (in_range_of_punch_attack && Time.time - time_tracker_punch > time_beetwen_punch_attack)
        {
            Vector3 pizda = player.transform.position - this.transform.position;

            player.GetComponent<Hero>().health -= punch_attack;
            time_tracker_punch = Time.time;

            // Debug.Log(pizda.magnitude);
        }
    }


    void obroc_do_playera()
    {
        Vector2 gracz = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 wrog = new Vector2(this.transform.position.x + Random.Range(0, 1f),
            this.transform.position.y + Random.Range(0, 1f));
        Vector2 result = new Vector2(gracz.x - wrog.x, gracz.y - wrog.y);
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -1 * Vector2.SignedAngle(result, Vector2.up)));
    }

    void obroc_do_punktu(Vector3 point)
    {
        Vector2 gracz = new Vector2(point.x, point.y);
        Vector2 wrog = new Vector2(this.transform.position.x + Random.Range(0, 1f),
            this.transform.position.y + Random.Range(0, 1f));
        Vector2 result = new Vector2(gracz.x - wrog.x, gracz.y - wrog.y);
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -1 * Vector2.SignedAngle(result, Vector2.up)));
    }

    void FillAmazingEffectList()
    {
        AmazingEffectFunctions.Add(GreenArrowsEffects);
        AmazingEffectFunctions.Add(RedArrowsEffects);
    }

    public void UseSpecialEffect(int index)
    {
        AmazingEffectFunctions[index]();
    }

    void GreenArrowsEffects()
    {
        float x = Random.Range(-0.2f, 0.2f);
        float y = Random.Range(-0.2f, 0.2f);
        Vector3 placment_bron = new Vector3(0f + x, 0f + y, 0f);
        if (weapon != null)
            Instantiate(M4, transform.position + placment_bron, transform.rotation);
        Destroy(gameObject);
    }

    void RedArrowsEffects()
    {

    }
}