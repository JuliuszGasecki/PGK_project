using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialWeaponsTutorial : MonoBehaviour
{
    public bool IsActive { set; get; }
    private float _time;
    private float _tempTimeScale;
    private bool _canContinue;
    private int SpaceCount = 0;
    private static int MAXSPACECOUNT = 5;
    public GameObject tutorial;
    public GameObject arrow;
    public GameObject highlightsSpecialWeapon;
    public GameObject highlightsDrugs;
    private Text _tutorialText;
    public GameObject drugsDictionary;

    private List<Action> functions;

    // Use this for initialization
    void Start()
    {
        _time = Time.time;
        functions = new List<Action>();
        functions.Add(FirstSpace);
        functions.Add(SecondSpace);
        functions.Add(ThirdSpace);
        functions.Add(FourthSpace);
        functions.Add(FifthSpace);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            tutorial.SetActive(true);
            _tempTimeScale = Time.timeScale;
            Time.timeScale = 0.000001f;
            IsActive = !IsActive;
            _canContinue = true;
            _tutorialText = GameObject.Find("SpecialWeaponTutorialText").GetComponent<Text>();
        }

        SpaceController();
    }

    void SpaceController()
    {
        if (Input.GetKey(KeyCode.Space) && _canContinue && Time.time > _time)
        {
            functions[SpaceCount]();
            SpaceCount++;
            _time = Time.time + 0.0000005f;
        }
    }

    void FirstSpace()
    {
        arrow.SetActive(true);
        highlightsSpecialWeapon.SetActive(true);
        _tutorialText.text =
            "Strzalka pokazuje gdzie aktualnie znajduje sie bron. Obok niej, z lewej strony, znajduje sie ikonka amunicji do Niej." +
            "Rozny kolor amunicji powoduje rozne efekty, ale tutaj nie moge Ci wiecej powiedziec";
    }

    void SecondSpace()
    {
        _tutorialText.text =
            "Amunicji do tej broni nie znajdziesz na ziemi. Musisz troche poglowkowac, moge Ci podpowiedziec, ze w zaleznosci jaki mix narkotykow znajdziesz, taki rodzaj amunicji mozesz aktualnie uzywac";
    }

    void ThirdSpace()
    {
        highlightsDrugs.SetActive(true);
        arrow.SetActive(false);
        highlightsSpecialWeapon.SetActive(false);
        drugsDictionary.SetActive(true);
        _tutorialText.text =
            "Dla przykladu drugi mix narkotykow da Ci amunicje, ktora powoduje....";
    }

    void FourthSpace()
    {
        drugsDictionary.SetActive(false);
        highlightsDrugs.SetActive(false);
        _tutorialText.text =
            "Musze juz uciekac, bo widze, ze robi sie goraco. Uwazaj na siebie, moze jeszcze kiedys sie spotkamy... Wcisnij space by zamknac";
    }

    void FifthSpace()
    {
        _canContinue = false;
        Time.timeScale = _tempTimeScale;
        tutorial.SetActive(false);
    }
}