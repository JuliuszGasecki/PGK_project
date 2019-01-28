using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossOne : MonoBehaviour
{

    public float chargeDistance;
    public float chargeLoading;
    // public float chargeTime;
    public int bossHealth;
    public int demage;
    public float area;
    public float chargeSpeed;
    public float normalSpeed;
    private GameObject hero;
    private float chargeTimer;
    bool coldown { get; set; }
    private bool chargeState;
    private AIDestinationSetter aItarget;
    private AIPath aIPath;
    private GameObject guide;
    private bool alive;
    public Sprite deadBoss;

    private Vector3 temporaryPosition;
    // Use this for initialization
    void Start()
    {
        aItarget = gameObject.GetComponent<AIDestinationSetter>();
        aIPath = gameObject.GetComponent<AIPath>();
        hero = GameObject.FindGameObjectWithTag("Player");
        chargeTimer = Time.time;
        guide = new GameObject();
        aItarget.target = guide.transform;
        chargeState = false;
        aIPath.maxSpeed = normalSpeed;
        coldown = true;
        alive = true;
    }

    private bool goodPoint(Vector3 newPostion)
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, newPostion);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Wall") return false;
            return true;
        }
        return true;
    }
    void Update()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);
        Debug.Log(bossHealth);
        if (coldown)
        {
            if (alive)
            {
                if (Time.time - chargeTimer > chargeLoading && !chargeState)
                {
                    temporaryPosition = hero.transform.position - this.gameObject.transform.position;
                    if (temporaryPosition.magnitude < chargeDistance)
                        temporaryPosition = temporaryPosition.normalized * chargeDistance;
                    temporaryPosition += this.gameObject.transform.position;
                    while (!goodPoint(temporaryPosition))
                    {
                        temporaryPosition -= temporaryPosition / 100;
                        Debug.Log("wtf");
                    }
                    chargeTimer = Time.time;
                    chargeState = true;
                }

                if (chargeState)
                {
                    guide.transform.position = temporaryPosition;
                    aIPath.maxSpeed = chargeSpeed;
                    if ((this.transform.position - temporaryPosition).magnitude < 0.01f) chargeState = false;
                }
                else if (!chargeState)
                {
                    guide.transform.position = hero.transform.position;
                    aIPath.maxSpeed = normalSpeed;
                }
            }
            else
            {

            }
        }
        else
        {
            chargeTimer = Time.time;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hero.GetComponent<Hero>().health -= demage;
        }

    }
}