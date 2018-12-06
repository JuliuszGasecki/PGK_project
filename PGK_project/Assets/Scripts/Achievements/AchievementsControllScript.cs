using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsControllScript : MonoBehaviour {
    public List<string> takenDrugs;
    public Text achievementsText;
    public Image achievementsImage;
    public GameObject panel;
    public Text achievementsTex1t;
    public Image achievementsImage1;
    public GameObject panel1;
    public Text achievementsText2;
    public Image achievementsImage2;
    public GameObject panel2;

    public Canvas achievementCanvas;
    public GameObject content;
    public Sprite heart;
    public Sprite lama;
    public Sprite cannabis;

    public GameObject achievement_box;

    // Use this for initialization
    void Start () {
        takenDrugs = new List<string>();




    }
	
	void Update () {
        giveAchievements();
    }

    int howManyTaken(string drug_name){
        return takenDrugs.FindAll((drug) => drug.Equals(drug_name)).Count;
    }
    public void addDrugAchievements(string drug_name){
        takenDrugs.Add(drug_name);
    }
    public bool checkIfOnlyTake(string drug_name){
        if (takenDrugs.TrueForAll((obj) => obj.Equals(drug_name)))
            return true;
        return false;
      }
   
     public void showTakeDrugs(){
        foreach (string i in takenDrugs)
            Debug.Log(i);
    }





    public void giveAchievements(){
        if (howManyTaken("ganja")  > 5)
        {

        }
        else{
            panel1.GetComponent<Image>().color = Color.gray;
           
        }
        if (howManyTaken("lsd") > 3)
        {

        }
        else{
            panel2.GetComponent<Image>().color = Color.gray;
        }

        if (howManyTaken("vodka") != 1)
        {
            panel.GetComponent<Image>().color = Color.gray;
        }
        else{

        }

    }


}
