using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHighlighted : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public GameObject shortInfoPanel;
    public Text text;
    public Dictionary<string, int> levelValue = new Dictionary<string, int>()
    {
        {"HomeTag0",0 },
        {"HomeTag0Done",0 },
        {"HomeName",0 },
        {"Text0",0 },
        
        {"DemoTag1",1 },
        {"DemoTag1Done",1 },
        {"DemoName",1 },
        {"Text1",1 },
        /*
        {"HomeTag1",1 },
        {"HomeTag1Done",1 },
        {"HomeName",1 },
        {"Text1",1 },
        */
        {"DiscoTag2",3 },
        {"DiscoTag2Done",3 },
        {"DiscoName",3 },
        {"Text2",3 },
        /*
        {"Home1Tag1",3 },
        {"Home1Tag1Done",3 },
        {"Home1Name",3 },
        {"Text11",3 },
        */
        {"MetroTag3",5 },
        {"MetroTag3Done",5 },
        {"MetroName",5 },
        {"Text4",5 },
        /*
        {"Home2Tag1",5 },
        {"Home2Tag1Done",5 },
        {"Home2Name",5 },
        {"Text21",5 },

        {"MetroTag3",6 },
        {"MetroTag0Done",6 },
        {"MetroName",6 },
        {"Text0",6 },
       */
    };

    public Dictionary<string, int> levelname = new Dictionary<string, int>()
    {
        {"Home",0 },
        {"Demo",1 },
        {"Home ",2 },
        {"Disco",3 },
        {"Home  ",4 },
        {"Metro",5 },
    };

    void Start()
    {
        text.GetComponent<Text>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        SetPosiosion(eventData);
        SetText(eventData);
        shortInfoPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        shortInfoPanel.SetActive(false);
        text.text = "";
    }

    public void SetPosiosion(PointerEventData eventData)
    {
        float x = eventData.pointerCurrentRaycast.gameObject.transform.position.x + 1.3f;
        float y = eventData.pointerCurrentRaycast.gameObject.transform.position.y + 1.3f;
        float z = eventData.pointerCurrentRaycast.gameObject.transform.position.z;

        shortInfoPanel.transform.position = new Vector3(x, y, z);
    }

    public void SetText(PointerEventData eventData)
    {
        string dane = "Next level to reach! \nClick to PLAY";
        string nazwa = eventData.pointerCurrentRaycast.gameObject.name;
        Debug.Log("Nazwa : " + nazwa);

        foreach (var item in LevelsStatistic.level_repo)
        {

            Debug.Log("Level " + item.Level_number + " Colected points " + (int)item.Level_points + " Stars: " + item.Level_stars);
            if (item.Level_number == (levelValue.FirstOrDefault(x => x.Key == nazwa).Value))
            {
                
                dane = "Level " + levelname.FirstOrDefault(x => x.Value == item.Level_number).Key + "\nColected points " + (int)item.Level_points + "\nStars: " + item.Level_stars
                    + "\nCombo: " + item.Level_numberOfCombo + "  Longest: " + item.Level_longestCombo;
            }

        }
        if (nazwa == "BackTag" || nazwa == "BackText")
        {
            dane = "Za pomoca tego znacznika mozesz wrocic do ostatniej rozgrywanej mapy.";
        }
        text.text = dane;
    }
}
