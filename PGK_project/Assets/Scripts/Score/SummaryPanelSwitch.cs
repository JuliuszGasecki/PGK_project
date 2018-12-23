using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummaryPanelSwitch : MonoBehaviour {

    public GameObject panelMain;
    public GameObject panelDetails;
    public void SummaryDetailsON()
    {
        panelMain.SetActive(false);
        panelDetails.SetActive(true);
    }

    public void SummaryDetailsOFF()
    {
        panelDetails.SetActive(false);
        panelMain.SetActive(true);
    }
}
