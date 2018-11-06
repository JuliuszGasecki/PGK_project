using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugsTimer : MonoBehaviour {



    public bool onDrugs;
    Hero hero;
    Withdrawal heroW;
    public bool tookDrug = false;

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

    // Use this for initialization
    void Start () {
        onDrugs = false;
        active_drugs = new List<DrugTemplate>();
        hero = GetComponent<Hero>();
        heroW  =GetComponent<Withdrawal>();
		
	}
	
	// Update is called once per frame
	void Update () {
        controllNarcotics();
    }
    public void addNarcotic(DrugTemplate drug){
        if (onDrugs != true)
            onDrugs = true;
        addEffect(drug);
        active_drugs.Add(drug);
    }


    public void zmien_flage_narkotyku(string nazwa_narkotyku, bool dziala)
    {
        Debug.Log(nazwa_narkotyku);
        if (nazwa_narkotyku == "ganja") { marihuanaFlag = dziala; }
        if (nazwa_narkotyku == "coca") { cocaFlag = dziala; }
        if (nazwa_narkotyku == "extasy") { extasyFlag = dziala; }
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
                DrugTemplate temp = active_drugs[i];
                if (Time.time - temp.getTimeOfUse() > temp.lifetime)
                {
                    removeNarcotic(temp);
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
        hero.poisoning += drug.poison_points;
        drug.setTimeOfUse(Time.time);
        heroW.addWithdrawalPoints(drug.withdroval_points);
        hero.speed += drug.speedBoost;
        hero.attack += drug.attackBoost;
    }

    public void removeEffect(DrugTemplate drug)
    {
        Time.timeScale = 1f;
        zmien_flage_narkotyku(drug.nazwa, false);
        hero.speed -= drug.speedBoost;
        hero.attack -= drug.attackBoost;
    }
    /*
    public void addExtasyTime()
    {
        extasyTime += 20f;
    }
    private void checkExtasy()
    {
        if(extasyTime>0)
        {
            tookDrug = true;
            extasyTime -= Time.fixedDeltaTime;
            extasySlider.value = extasyTime;
            if(extasyFlag == false)
            {
                useExtasy();
            }
            extasyFlag = true;
        }
        else if(extasyFlag == true)
        {
            resetExtasy();
            extasyFlag = false;
        }
    }
    private void useExtasy()
    {
        hero.speed += 5;
        
        heroW.addWithdrawalPoints(10);
    }
    private void resetExtasy()
    {
        hero.speed -= 5;
        heroW.addWithdrawalPoints(7);
    }

    public void addMarihuanaTime()
    {
        marihuanaTime += 50f;
    }
    private void checkMarihuana()
    {
        if (marihuanaTime > 0)
        {
            tookDrug = true;
            marihuanaTime -= Time.fixedDeltaTime;
            marihuanaSlider.value = marihuanaTime;
            if (marihuanaFlag == false)
            {
                useMarihuana();
            }
            marihuanaFlag = true;
        }
        else if (marihuanaFlag == true)
        {
            resetMarihuana();
            marihuanaFlag = false;
        }
    }

    private void useMarihuana()
    {
        Time.timeScale = 0.2f;
        hero.speed += 5;
        heroW.stopWithdrawal();

    }
    private void resetMarihuana()
    {
        Time.timeScale = 1f;
        hero.speed -= 5;
        heroW.startWithdrawal();
        heroW.addWithdrawalPoints(10);
    }

    public void addCocaTime()
    {
        cocaTime += 10f;
    }
    private void checkCoca()
    {
        if (cocaTime > 0)
        {
            tookDrug = true;
            cocaTime -= Time.fixedDeltaTime;
            cocaSlider.value = cocaTime;
            if (cocaFlag == false)
            {
                useCoca();
            }
            cocaFlag = true;
        }
        else if (cocaFlag == true)
        {
            resetCoca();
            cocaFlag = false;
        }
    }

    private void useCoca()
    {
        hero.speed += 7;
        hero.attack += 10;
        heroW.addWithdrawalPoints(15);

    }
    private void resetCoca()
    {
        hero.speed -= 7;
        heroW.startWithdrawal();
        heroW.addWithdrawalPoints(12);
    }
*/
}
