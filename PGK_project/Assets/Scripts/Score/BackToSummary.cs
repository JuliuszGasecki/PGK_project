using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToSummary : MonoBehaviour {

    public GameObject panel;
    public void SummaryDetailsON()
    {
        panel.SetActive(true);
    }

    public void SummaryDetailsOFF()
    {
        panel.SetActive(false);
    }
}
