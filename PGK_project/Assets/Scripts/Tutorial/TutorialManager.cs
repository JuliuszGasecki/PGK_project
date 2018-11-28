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
        hero = GameObject.Find("Hero").GetComponent<Withdrawal>();
        teacher.enabled = true;
        teacher.sprite = teacherSprite;
        SetNextTutorial(0);
        hero.stopWithdrawal();
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
        SetNextTutorial(currentTutorial.order + 1);
    }

    public void SetNextTutorial(int currentOrder)
    {
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
        tutorialText.enabled = false;
        hero.startWithdrawal();
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
