using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugsDiary : MonoBehaviour {

    [SerializeField]
    public List<DrugNote> drugs;
    [SerializeField]
    public List<MixNote> mixes;

    [SerializeField]
    private Image drugImage1;
    [SerializeField]
    private Image drugImage2;
    [SerializeField]
    private Image drugImage3;
    [SerializeField]
    private Text text1;
    [SerializeField]
    private Text text2;
    [SerializeField]
    private Text text3;

    [SerializeField]
    private Image MixImage11;
    [SerializeField]
    private Image MixImage12;
    [SerializeField]
    private Image MixImage13;
    [SerializeField]
    private Image MixImage21;
    [SerializeField]
    private Image MixImage22;
    [SerializeField]
    private Image MixImage23;
    [SerializeField]
    private Image MixImage31;
    [SerializeField]
    private Image MixImage32;
    [SerializeField]
    private Image MixImage33;
    [SerializeField]
    private Text textMix1;
    [SerializeField]
    private Text textMix2;
    [SerializeField]
    private Text textMix3;

    private bool mode; //true -> drug, false -> mix
    private int currentIndex = 0;

    private static DrugsDiary drugsDiaryInstance;
    public static DrugsDiary DrugsDiaryInstance
    {
        get
        {
            if (drugsDiaryInstance == null)
            {
                drugsDiaryInstance = GameObject.FindObjectOfType<DrugsDiary>();
            }
            return drugsDiaryInstance;
        }
    }

    void Start () {
        mode = true;
	}

    public void setNextPage()
    {
        if (mode)
        {
            currentIndex += 3;
            if(currentIndex > drugs.Count)
            {
                mode = !mode;
                currentIndex = 0;
            }
            loadPage();
        }
        else
        {
            currentIndex += 3;
            if (currentIndex > mixes.Count)
            {
                mode = !mode;
                currentIndex = 0;
            }
            loadPage();
        }
    }

    private void loadPage()
    {
        if (mode)
        {
            if(drugs[currentIndex] != null && drugs[currentIndex].isDiscovered)
            {
                text1.text = drugs[currentIndex].explenation;
                drugImage1.sprite = drugs[currentIndex].narcoSprite;
            }
            else
            {
                text1.text = "";
                drugImage1.sprite = null;
            }
            if (drugs[currentIndex + 1] != null && drugs[currentIndex + 1].isDiscovered)
            {
                text2.text = drugs[currentIndex + 1].explenation;
                drugImage2.sprite = drugs[currentIndex + 1].narcoSprite;
            }
            else
            {
                text2.text = "";
                drugImage2.sprite = null;
            }
            if (drugs[currentIndex + 2] != null && drugs[currentIndex + 2].isDiscovered)
            {
                text3.text = drugs[currentIndex + 1].explenation;
                drugImage3.sprite = drugs[currentIndex + 1].narcoSprite;
            }
            else
            {
                text3.text = "";
                drugImage3.sprite = null;
            }
        }
        else
        {
            if (mixes[currentIndex] != null && mixes[currentIndex].isDiscovered)
            {
                textMix1.text = mixes[currentIndex].text;
                MixImage11.sprite = mixes[currentIndex].firstNarcoSprite;
                MixImage12.sprite = mixes[currentIndex].secondNarcoSprite;
                MixImage13.sprite = mixes[currentIndex].mixSprite;
            }
            else
            {
                textMix1.text = "";
                MixImage11.sprite = null;
                MixImage12.sprite = null;
                MixImage13.sprite = null;
            }
            if (mixes[currentIndex + 1] != null && mixes[currentIndex + 1].isDiscovered)
            {
                textMix2.text = mixes[currentIndex].text;
                MixImage21.sprite = mixes[currentIndex].firstNarcoSprite;
                MixImage22.sprite = mixes[currentIndex].secondNarcoSprite;
                MixImage23.sprite = mixes[currentIndex].mixSprite;
            }
            else
            {
                textMix2.text = "";
                MixImage21.sprite = null;
                MixImage22.sprite = null;
                MixImage23.sprite = null;
            }
            if (mixes[currentIndex + 2] != null && mixes[currentIndex + 2].isDiscovered)
            {
                textMix3.text = mixes[currentIndex].text;
                MixImage31.sprite = mixes[currentIndex].firstNarcoSprite;
                MixImage32.sprite = mixes[currentIndex].secondNarcoSprite;
                MixImage33.sprite = mixes[currentIndex].mixSprite;
            }
            else
            {
                textMix3.text = "";
                MixImage31.sprite = null;
                MixImage32.sprite = null;
                MixImage33.sprite = null;
            }
        }

    }

    public void setPreviousPage()
    {
        if (mode)
        {
            currentIndex -= 3;
            if (currentIndex < 0)
            {
                mode = !mode;
                currentIndex = 0;
            }
            loadPage();
        }
        else
        {
            currentIndex -= 3;
            if (currentIndex < 0)
            {
                mode = !mode;
                currentIndex = 0;
            }
            loadPage();
        }
    }

    public void checkDiscovered()
    {
        foreach(DrugNote a in drugs)
        {
            if(!a.isDiscovered)
            {
                if(GlobalDrugsVariables.alcoOnceTaken && a._name == "alco")
                {
                    a.isDiscovered = true;
                }
                else if (GlobalDrugsVariables.heraOnceTaken && a._name == "hera")
                {
                    a.isDiscovered = true;
                }
                else if (GlobalDrugsVariables.cocoOnceTaken && a._name == "coco")
                {
                    a.isDiscovered = true;
                }
                else if (GlobalDrugsVariables.weedOnceTaken && a._name == "weed")
                {
                    a.isDiscovered = true;
                }
                else if (GlobalDrugsVariables.cigaretteOnceTaken && a._name == "cigarette")
                {
                    a.isDiscovered = true;
                }
                else if (GlobalDrugsVariables.methOnceTaken && a._name == "meth")
                {
                    a.isDiscovered = true;
                }
                else if (GlobalDrugsVariables.extasyOnceTaken && a._name == "extasy")
                {
                    a.isDiscovered = true;
                }
                else if (GlobalDrugsVariables.lsdOnceTaken && a._name == "lsd")
                {
                    a.isDiscovered = true;
                }
                else if (GlobalDrugsVariables.mocarzOnceTaken && a._name == "mocarz")
                {
                    a.isDiscovered = true;
                }
            }

        }
        foreach (MixNote a in mixes)
        {
            if (!a.isDiscovered)
            {
                if (GlobalDrugsVariables.alcoHeraOnceTaken && a._name == "alcoHera")
                {
                    a.isDiscovered = true;
                }
                else if (GlobalDrugsVariables.cocoHeraOnceTaken && a._name == "cocoHera")
                {
                    a.isDiscovered = true;
                }
                else if (GlobalDrugsVariables.alcoSpeedOnceTaken && a._name == "alcoSpeed")
                {
                    a.isDiscovered = true;
                }
                else if (GlobalDrugsVariables.cocoMaryOnceTaken && a._name == "cocoMary")
                {
                    a.isDiscovered = true;
                }
                else if (GlobalDrugsVariables.cocoMDMAOnceTaken && a._name == "cocoMDMA")
                {
                    a.isDiscovered = true;
                }
                else if (GlobalDrugsVariables.methHangoverOnceTaken && a._name == "methHangover")
                {
                    a.isDiscovered = true;
                }
                else if (GlobalDrugsVariables.cocoLSDOnceTaken && a._name == "cocoLSD")
                {
                    a.isDiscovered = true;
                }
                else if (GlobalDrugsVariables.maryCigarOnceTaken && a._name == "maryCigar")
                {
                    a.isDiscovered = true;
                }
            }
        }
    }
	
	void Update () {
        checkDiscovered();
	}
}
