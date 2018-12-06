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
    Dictionary<string, GameObject> sliders;
    private float max = 15;

    public GameObject extasySlider;
    public GameObject cocaSlider;
    public GameObject marihuanaSlider;
    public GameObject heroinSlider;
    public GameObject vodkaSlider;
    public GameObject lsdSlider;
    public GameObject mocarzSlider;

    public AchievementsControllScript achievementsControll;


    public bool extasyFlag = false;

    public bool marihuanaFlag = false;

    public bool cocaFlag = false;

    public bool heroineFlag = false;
    public bool vodkaFlag = false;
    public bool mocarzFlag = false;
    public bool lsdFlag = false;
    // Use this for initialization
    void Start() {
        onDrugs = false;
        active_drugs = new List<DrugTemplate>();
        hero = GetComponent<Hero>();
        heroW = GetComponent<Withdrawal>();
        time = Time.time;
        sliders = createSliders();
        //achievementsControll = 
        achievementsControll = hero.GetComponent<AchievementsControllScript>();//.GetComponent<AchievementsControllScript>())
    }

    Dictionary<string, GameObject> createSliders()
        {
        Dictionary<string, GameObject> temp = new Dictionary<string, GameObject>();
        temp.Add("extasy", extasySlider);
        temp.Add("coca", cocaSlider);
        temp.Add("ganja", marihuanaSlider);
        temp.Add("hera", heroinSlider);
        temp.Add("vodka", vodkaSlider);
        temp.Add("mocarz", mocarzSlider);
        temp.Add("lsd", lsdSlider);
        return temp;
        }
	
	// Update is called once per frame
	void Update () {
        controllNarcotics();
        drawSliders();
        time = Time.time;

    }
    public void addNarcotic(DrugTemplate drug){
        //achievementsControll.addDrugAchievements(drug.nazwa);//to jest do kontrolli achievementow
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
        if (nazwa_narkotyku == "ganja") { marihuanaFlag = dziala; sliders[nazwa_narkotyku].SetActive(true); }
        if (nazwa_narkotyku == "coca") { cocaFlag = dziala; sliders[nazwa_narkotyku].SetActive(true); }
        if (nazwa_narkotyku == "extasy") { extasyFlag = dziala; sliders[nazwa_narkotyku].SetActive(true); }
        if (nazwa_narkotyku == "hera") { heroineFlag = dziala; sliders[nazwa_narkotyku].SetActive(true); }
        if (nazwa_narkotyku == "vodka") { vodkaFlag = dziala; sliders[nazwa_narkotyku].SetActive(true); }
        if (nazwa_narkotyku == "mocarz") { mocarzFlag = dziala; sliders[nazwa_narkotyku].SetActive(true); }
        if (nazwa_narkotyku == "lsd") { lsdFlag = dziala; sliders[nazwa_narkotyku].SetActive(true); }
    }


    public void removeNarcotic(DrugTemplate drug){
        removeEffect(drug);
        active_drugs.Remove(drug);
        sliders[drug.nazwa].SetActive(false);
        Debug.Log("Usunieto " + drug.nazwa);
    }
    public void removeNarcotic(string drugName)
    {
        if (active_drugs.Count > 0)
        {
            for (int i = 0; i < active_drugs.Count; i++)
            {
                if (active_drugs[i].nazwa == drugName)
                {
                    removeNarcotic(active_drugs[i]);
                    break;
                }

            }
        }
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
        if (dt.nazwa == "ganja") { marihuanaSlider.GetComponent<Image>().fillAmount = dt.lifetime / max; }
        if (dt.nazwa == "coca") { cocaSlider.GetComponent<Image>().fillAmount = dt.lifetime / max; }
        if (dt.nazwa == "extasy") {extasySlider.GetComponent<Image>().fillAmount = dt.lifetime/max; }
        if (dt.nazwa == "hera") { heroinSlider.GetComponent<Image>().fillAmount = dt.lifetime / max; }
        if (dt.nazwa == "vodka") { vodkaSlider.GetComponent<Image>().fillAmount = dt.lifetime / max; }
        if (dt.nazwa == "mocarz") { mocarzSlider.GetComponent<Image>().fillAmount = dt.lifetime / max; }
        if (dt.nazwa == "lsd") { lsdSlider.GetComponent<Image>().fillAmount = dt.lifetime / max; }
        }
        
    }
}
