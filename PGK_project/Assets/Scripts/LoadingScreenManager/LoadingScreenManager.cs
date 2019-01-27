using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour {

    private float time;
    public static string nameScene = "DemoScene";

    public GameObject image0;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;


    void Start()
    {
        time = Time.time;
        SetScreen();
    }

    void Update()
    {
        if(Time.time - time > 3)
        {
            DrugsStat.AllStatsReset();
            // SceneManager.LoadScene("Required");
            SceneManager.LoadScene(nameScene);
            // SceneManager.LoadScene("home");
        }
    }

    public void SetScreen()
    {
        SetUnvisiable();
        if (DrugsStat.level == 0)
        {
            image0.SetActive(true);
        }
        else if (DrugsStat.level == 1)
        {
            image1.SetActive(true);
        }
        else if (DrugsStat.level == 2)
        {
            image2.SetActive(true);
        }
        else if (DrugsStat.level == 3)
        {
            image3.SetActive(true);
        }
        else if (DrugsStat.level == 4)
        {
            image4.SetActive(true);
        }
        else if (DrugsStat.level == 5)
        {
            image5.SetActive(true);
        }
    }

    public void SetUnvisiable()
    {
        image0.SetActive(false);
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
        image4.SetActive(false);
        image5.SetActive(false);
    }

}
