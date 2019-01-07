using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataSet : MonoBehaviour {

    public Text textFirst;
    public GameObject First;
    public Text textSecond;
    public GameObject Second;
    public Text textThird;
    public GameObject Third;
    public Text textForth;
    public GameObject Forth;
    public Text textFifth;
    public GameObject Fifth;
    public Text textSixth;
    public GameObject Sixth;
    public Text textSeventh;
    public GameObject Seventh;
    public List<GameObject> lista = new List<GameObject>();
    void Start ()
    {
        lista.Add(First);
        lista.Add(Second);
        lista.Add(Third);
        lista.Add(Forth);
        lista.Add(Fifth);
        lista.Add(Sixth);
        lista.Add(Seventh);
        switch (LoadingScreenManager.nameScene)
        {
            case "DemoScene":
                SetData0();
                break;
            case "Home":
                SetData1();
                break;
            case "Disco":
                SetData2();
                break;
            case "LevelsMap":
                SetData_loading();
                break;
        default:
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetData0()
    {
        foreach (var item in lista)
        {
            item.SetActive(true);
        }
        textFirst.text = "Zbieraj narkotyki! Kazdy dzialka to jeden punkt do calosc punktow. ";
        textSecond.text = "Odkrywaj combosy! Odpowiednia kombinacja narkotykow spowoduje niezle efekty - probuj ich, a za kazdy zostaniesz wynagrodzony";
        textThird.text = "Masz ze soba bron! Jesli ktos Ci stanie na drodze,mozesz jej uzyc! Kazde zabojstwo to dodatkowy punkt i bonus w postaci 2.7 punkta!";
        textForth.text = "Jesli Cie poniesie i zabijesz kilku agentow pod rzad - uzbierane za runde punkty zostana pomnozone przez bonus za combo";
        textFifth.text = "Na przejscie rundy masz okreslony czas (ta runda 40s), ale nie martw sie- gdy nie dasz rady- uzbierane punkty beda stopniowo malec";
        textSixth.text = "Aby przejsc ten poziom musisz zdobyc co najmniej 15 punktow!";
        textSeventh.text = "Z czasem dowiesz sie wiecej jak przezyc w tym swiecie!";
    }
    public void SetData1()
    {
        for (int i = 0; i < 4; i++)
        {
            lista[i].SetActive(true);
        }
        for (int i = 4; i < 7; i++)
        {
            lista[i].SetActive(false);
        }
        textFirst.text = "Dom - tutaj mozesz pochillowac, chwila oddechu od szybkiego tempa w miescie";
        textSecond.text = "Nie zbierasz tutaj punktow, ale czekaja Cie inne atrakcje";
        textThird.text = "Odkryj wszystkie charaterystyczne elementy w domu";
        textForth.text = "Wyjdz do klubu - na koncu mieszkania masz drzwi na miasto";
    }
    public void SetData2()
    {
        for (int i = 0; i < 5; i++)
        {
            lista[i].SetActive(true);
        }
        for (int i = 5; i < 7; i++)
        {
            lista[i].SetActive(false);
        }
        textFirst.text = "jestesmy w klubie";
        textSecond.text = "0";
        textThird.text = "0";
        textForth.text = "0";
        textFifth.text = "0";
        textSixth.text = "0";
        textSeventh.text = "0";
    }

    public void SetData_loading()
    {
        SceneManager.LoadScene("LevelsMap");
    }
}
