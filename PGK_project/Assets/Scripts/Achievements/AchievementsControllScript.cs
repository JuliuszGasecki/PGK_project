using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsControllScript : MonoBehaviour
{
    public Image myHead;
    public List<GameObject> enemy;
    public List<string> mixes;
    private int enemyShoot;
    private int enemyFight;
    private int deadShoot;
    private int deadFight;
    private int enemyNumber;
    private Hero hero;



    public List<string> takenDrugs;
    //  public Text achievementsText;
    //public Image achievementsImage;
    public GameObject panel;
    //    public Text achievementsTex1t;
    //  public Image achievementsImage1;
    public GameObject panel1;
    //public Text achievementsText2;
    //public Image achievementsImage2;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;

    public Canvas achievementCanvas;
    public GameObject content;
    public Sprite heart;
    public Sprite lama;
    public Sprite cannabis;

    public GameObject achievement_box;

    // Use this for initialization
    void Start()
    {
        hero = gameObject.GetComponent<Hero>();
        enemyShoot = 0; enemyFight = 0; deadFight = 0; deadShoot = 0;
        takenDrugs = new List<string>();
        countEnemys();
    }
    void countEnemys()
    {
        enemy = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        enemyNumber = enemy.Count;
        foreach (GameObject en in enemy)
        {
            if (en.gameObject.GetComponent<Enemy2>().isStatic) enemyShoot++;
            else enemyFight++;
        }
    }
    void countDeadEnemys()
    {
        for (int i = 0; i < enemy.Count; i++)
        {
            GameObject en = enemy[i];
            if (!en.gameObject.GetComponent<Enemy2>().alive)
            {
                if (en.gameObject.GetComponent<Enemy2>().isStatic) deadShoot++;
                else deadFight++;
            }
        }
        enemy.RemoveAll((GameObject obj) => obj.gameObject.GetComponent<Enemy2>().alive == false);
    }
    void Update()
    {
        giveAchievements();
        countDeadEnemys();
        Debug.Log(deadFight + " f");
        Debug.Log(deadShoot + " s");
        Debug.Log(enemy.Count + " c ");

    }

    int howManyTaken(string drug_name)
    {
        return takenDrugs.FindAll((drug) => drug.Equals(drug_name)).Count;
    }
    public void addDrugAchievements(string drug_name)
    {
        takenDrugs.Add(drug_name);
    }
    public void addMix(string mix) { mixes.Add(mix); }
    public int howManyMix(string mix) { return mixes.FindAll((obj) => obj.Equals(mix)).Count; }

    public bool checkIfOnlyTake(string drug_name)
    {
        if (takenDrugs.TrueForAll((obj) => obj.Equals(drug_name)))
            return true;
        return false;
    }

    public void showTakeDrugs()
    {
        foreach (string i in takenDrugs)
            Debug.Log(i);
    }





    public void giveAchievements()
    {
        if (howManyTaken("ganja") > 5)
        {
            panel1.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            panel1.GetComponent<Image>().color = Color.red;

        }
        if (howManyTaken("lsd") > 3)
        {
            panel2.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            panel2.GetComponent<Image>().color = Color.red;
        }

        if (howManyTaken("vodka") == 1)
        {
            panel.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            panel.GetComponent<Image>().color = Color.red;
        }



        if (deadShoot == enemyShoot && deadFight == 0)
        {
            panel3.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            panel3.GetComponent<Image>().color = Color.red;
        }
        if (mixes.Count > 10)
        {
            panel4.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            panel4.GetComponent<Image>().color = Color.red;
        }

        if (hero.maxHeath <= hero.health && enemyNumber == enemy.Count)
        {
            panel5.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            panel5.GetComponent<Image>().color = Color.red;
        }

    }
}
