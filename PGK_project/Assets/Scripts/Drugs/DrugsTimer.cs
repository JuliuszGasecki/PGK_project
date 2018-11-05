using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugsTimer : MonoBehaviour {

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
        active_drugs = new List<DrugTemplate>();
        hero = GetComponent<Hero>();
        heroW  =GetComponent<Withdrawal>();
		
	}
	
	// Update is called once per frame
	void Update () {
        checkExtasy();
        checkMarihuana();
        checkCoca();
        controllNarcotics();
    }
    public void addNarcotic(DrugTemplate drug){
        drug.destroyObject();
        drug.setTimeOfUse(Time.time);
        //add atributes
        hero.speed += drug.speedBoost;
        hero.attack += drug.attackBoost;
        //
        active_drugs.Add(drug);
    }


    public void removeNarcotic(DrugTemplate drug){
        //remove atribtutes
        hero.speed -= drug.speedBoost;
        hero.attack -= drug.attackBoost;
        //remova atributes
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
    }


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

}
