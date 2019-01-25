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
        {"DemoTag0",0 },
        {"DemoTag0Done",0 },
        {"DemoName",0 },
        {"Text0",0 },

        {"HomeTag1",1 },
        {"HomeTag1Done",1 },
        {"HomeName",1 },
        {"Text1",1 },

        {"DiscoTag2",2 },
        {"DiscoTag2Done",2 },
        {"DiscoName",2 },
        {"Text2",2 }
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
        string dane = "Not reached";
        string nazwa = eventData.pointerCurrentRaycast.gameObject.name;
        //Debug.Log("Nazwa : " + nazwa);

        foreach (var item in LevelsStatistic.level_repo)
        {

           // Debug.Log("Level " + item.Level_number + " Colected points " + (int)item.Level_points + " Stars: " + item.Level_stars);
            if (item.Level_number == (levelValue.FirstOrDefault(x => x.Key == nazwa).Value))
            {
                dane = "Level " + item.Level_number + "\nColected points " + (int)item.Level_points + "\nStars: " + item.Level_stars
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
