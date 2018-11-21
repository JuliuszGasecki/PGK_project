using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugsTimer : MonoBehaviour {



    public bool onDrugs;
    Hero hero;
    Withdrawal heroW;
    public bool tookDrug = false;
    float time;
    List<DrugTemplate> active_drugs;
    
    public Slider extasySlider;
    public float extasyTime = 0f;
    public bool extasyFlag = false;

    public Slider marihuanaSlider;
    public float marihuanaTime = 0f;
    public bool marihuanaFlag = false;

    public Slider cocaSlider;
    public float cocaTime = 0f;
    public bool cocaFlag = false;

    public bool heroineFlag = false;
    public bool vodkaFlag = false;
    public bool mocarzFlag = false;
    public bool lsdFlag = false;
    // Use this for initialization
    void Start () {
        onDrugs = false;
        active_drugs = new List<DrugTemplate>();
        hero = GetComponent<Hero>();
        heroW  =GetComponent<Withdrawal>();
        time = Time.time;

    }
	
	// Update is called once per frame
	void Update () {
        controllNarcotics();
        drawSliders();
        time = Time.time;

    }
    public void addNarcotic(DrugTemplate drug){
        if (onDrugs != true)
            onDrugs = true;

        if(!active_drugs.Contains(drug))
        {
            addEffect(drug);
            active_drugs.Add(drug);
        }
        else
        {
            int i = active_drugs.FindIndex(a => a.name == drug.name);
            active_drugs[i].addTimeofuse(4);
        }

    }


    public void zmien_flage_narkotyku(string nazwa_narkotyku, bool dziala)
    {
        Debug.Log(nazwa_narkotyku);
        if (nazwa_narkotyku == "ganja") { marihuanaFlag = dziala; }
        if (nazwa_narkotyku == "coca") { cocaFlag = dziala; }
        if (nazwa_narkotyku == "extasy") { extasyFlag = dziala; }
        if (nazwa_narkotyku == "hera") { heroineFlag = dziala; }
        if (nazwa_narkotyku == "vodka") { vodkaFlag = dziala; }
        if (nazwa_narkotyku == "mocarz") { mocarzFlag = dziala; }
        if (nazwa_narkotyku == "lsd") { lsdFlag = dziala; }


    }


    public void removeNarcotic(DrugTemplate drug){
        removeEffect(drug);
        active_drugs.Remove(drug);
       
    }

    public void controllNarcotics(){
          if (active_drugs.Count > 0)
          {
              for (int i = 0; i < active_drugs.Count; i++)
              {
                  float temp = active_drugs[i].lifetime - (Time.time - time)*1.3f;
                //active_drugs[i].timeLeft = Time.time - temp.getTimeOfUse();
                active_drugs[i].lifetime -= (Time.time - time) * 1.3f;
                if (temp <= 0)
                  {
                      removeNarcotic(active_drugs[i]);
                  }
                  
              }
          }
          else
              onDrugs = false; // nie ma nic

    }

    public void addEffect(DrugTemplate drug){

        if (Time.timeScale > drug.time_scale) //zeby zawsze najnizszy byl
            Time.timeScale = drug.time_scale;
        zmien_flage_narkotyku(drug.nazwa, true);
        addPoints(drug);
        hero.poisoning += drug.poison_points;
        //drug.setTimeOfUse(Time.time);
        heroW.addWithdrawalPoints(drug.withdroval_points);
        hero.speed += drug.speedBoost;
        hero.attack += drug.attackBoost;
        hero.health += drug.lifeBoost;
    }

    public void removeEffect(DrugTemplate drug)
    {
        if (drug.nazwa == "ganja")
        {
            Time.timeScale = 1f;
        }    
        zmien_flage_narkotyku(drug.nazwa, false);
        hero.speed -= drug.speedBoost;
        hero.attack -= drug.attackBoost;
    }

    public void addPoints(DrugTemplate drug)
    {
        DrugsStat.drugsValue++;
        if (drug.nazwa == "ganja") DrugsStat.drugsMariValue++;
        if (drug.nazwa == "coca") DrugsStat.drugsCocaValue++;
        if (drug.nazwa == "extasy") DrugsStat.drugsExtasyValue++;
    }

    public void drawSliders()
    {
        foreach(DrugTemplate dt in active_drugs)
            {
        if (dt.nazwa == "ganja") { marihuanaSlider.value = dt.lifetime; }
        if (dt.nazwa == "coca") { cocaSlider.value = dt.lifetime; }
        if (dt.nazwa == "extasy") { extasySlider.value = dt.lifetime; }
        if (dt.nazwa == "hera") {  }
        if (dt.nazwa == "vodka") {  }
        }
        
    }
}
