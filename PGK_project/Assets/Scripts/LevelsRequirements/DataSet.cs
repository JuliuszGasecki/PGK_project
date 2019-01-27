using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataSet : MonoBehaviour {

    public Text textLevel;
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

        SetData0();
    }

    public void SetData0()
    {
        textLevel.text = "0";
        textLevel.text = "1";
        for (int i = 0; i < 4; i++)
        {
            lista[i].SetActive(true);
        }
        for (int i = 4; i < 7; i++)
        {
            lista[i].SetActive(false);
        }
        textFirst.text = "Punkty w grze zdobedziesz za narkotyki, zabojstwa i ich combo oraz premie czasowe";
        textSecond.text = "Na przejscie kazdej rundy masz okreslony czas - poziom 1 - 40 sekund, po tym czasie uzbierane punkty beda stopniowo malec ";
        textThird.text = "Aby przejsc na nastepny etap musisz uzbierac co najmniej 15 punktow!";
        textForth.text = "POWODZENIA!";
    }

    public void SetData_loading()
    {
        SceneManager.LoadScene("LevelsMap");
    }
}
