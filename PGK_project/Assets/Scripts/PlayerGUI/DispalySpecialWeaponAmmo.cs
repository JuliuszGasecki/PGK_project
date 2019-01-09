using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispalySpecialWeaponAmmo : MonoBehaviour
{
    private Inventory weapon;
    private Image image;
    private Sprite sprite;
    private List<string> _arrowNames;
    private bool IsImage;
    private float _firstPosX = -266.2f;
    private float _firstPosY = 76.0f;
    private float _width = 50.0f;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        _arrowNames = new List<string>(new string[] {"arrow1r", "arrow2g"});
    }

    // Update is called once per frame
    void Update()
    {
        weapon = GameObject.Find("Inventory").GetComponent<Inventory>();
        if (weapon.GetUsingSpecialWeapon() == null)
        {
            image.enabled = false;
            IsImage = false;
        }
        else if (Time.timeScale == 0f) //usun icon w summaryPanel
        {
            image.enabled = false;
            IsImage = false;
        }
        else
        {
            int indexArrow = weapon.ReturnDrugsMix();
            if (indexArrow >= 0)
            {
                image.enabled = true;
                IsImage = true;
                image.type = Image.Type.Filled;
                image.fillMethod = Image.FillMethod.Radial360;
                image.sprite = Resources.Load<Sprite>("Weapons/" + _arrowNames[indexArrow]);
                weapon.GetComponent<CROSSBOW>().NarcoMixId = indexArrow;
            }
        }
    }
}