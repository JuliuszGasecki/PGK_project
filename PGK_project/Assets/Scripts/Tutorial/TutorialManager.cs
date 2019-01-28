using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    public List<Tutorial> Tutorials = new List<Tutorial>();

    public Text tutorialText;
    public Image teacher;
    public Sprite teacherSprite;
    public string finishTutorial;
    public List<Sprite> sprites;
    public Image tutImage;
    Withdrawal hero;

    private static TutorialManager instance;
    public static TutorialManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<TutorialManager>();
            }
            return instance;
        }
    }

    private Tutorial currentTutorial;

	// Use this for initialization
	void Start () {
       
        if (TutekOdwiedzon.odwiedzon)
        {
            teacher.enabled = false;
            tutorialText.enabled = false;
            Destroy(gameObject);
        }
        else
        {
            hero = GameObject.Find("Hero").GetComponent<Withdrawal>();
            teacher.enabled = true;
            teacher.sprite = teacherSprite;

            SetNextTutorial(0);
            hero.stopWithdrawal();
        }
        

    }
	
	// Update is called once per frame
	void Update () {
		if(currentTutorial)
        {
            currentTutorial.CheckIfHappening();
        }
	}

    public void CompletedTutorial()
    {
        if (TutekOdwiedzon.odwiedzon)
        {
            teacher.enabled = false;
            tutorialText.enabled = false;
            Destroy(gameObject);
        }
        else
        {
            SetNextTutorial(currentTutorial.order + 1);
        }
        
    }

    public void SetNextTutorial(int currentOrder)
    {
        if (TutekOdwiedzon.odwiedzon)
        {
            teacher.enabled = false;
            tutorialText.text = null;
            Destroy(gameObject);
        }
        if (currentOrder > 0 && currentOrder < 6 || currentOrder == 10)
        {
            tutImage.enabled = true;
            tutImage.sprite = sprites[currentOrder];
        }
        else
        {
            tutImage.enabled = false;
        }
        currentTutorial = getTutorialByOrder(currentOrder);
        if(!currentTutorial)
        {
            CompleteAllTutorials();
            
            return;
        }

        tutorialText.text = currentTutorial.Explanation;
    }

    public void CompleteAllTutorials()
    {
        tutorialText.text = finishTutorial;
        teacher.enabled = false;
        tutorialText = null;
        hero.startWithdrawal();
        Time.timeScale = 1f;
        TutekOdwiedzon.odwiedzon = true;
        Destroy(gameObject);
    }


    public Tutorial getTutorialByOrder(int Order)
    {
        for(int i = 0; i < Tutorials.Count; i++)
        {
            if (Tutorials[i].order == Order)
                return Tutorials[i];
        }
        return null;
    }

}
