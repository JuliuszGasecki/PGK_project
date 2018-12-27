using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitch : MonoBehaviour {

    public GameObject panelMurder;
    public GameObject panelNarcotics;
    public GameObject panelAchivements;
    public GameObject panelOther;

	// Use this for initialization
	void Start ()
    {
        panelMurder.SetActive(false);
        panelNarcotics.SetActive(false);
        panelAchivements.SetActive(false);
        panelOther.SetActive(false);
    }
	
    public void ShowMurder()
    {
        panelMurder.SetActive(true);
        panelNarcotics.SetActive(false);
        panelAchivements.SetActive(false);
        panelOther.SetActive(false);

    }

    public void ShowNarcoticts()
    {
        panelMurder.SetActive(false);
        panelNarcotics.SetActive(true);
        panelAchivements.SetActive(false);
        panelOther.SetActive(false);

    }

    public void ShowAchivements()
    {
        panelMurder.SetActive(false);
        panelNarcotics.SetActive(false);
        panelAchivements.SetActive(true);
        panelOther.SetActive(false);

    }

    public void ShowOther()
    {
        panelMurder.SetActive(false);
        panelNarcotics.SetActive(false);
        panelAchivements.SetActive(false);
        panelOther.SetActive(true);

    }
}
