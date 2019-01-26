using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public List<Dialogue> Dialogues = new List<Dialogue>();

    private Text DialogueText;
    private Image interlocutor;
    public Sprite interlocutorSprite;
    public string finishDialogue;
    private GameObject hero;
    private float previousSpeed;

    public GameObject blur;

    private static DialogueManager instance;
    public static DialogueManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<DialogueManager>();
            }
            return instance;
        }
    }
    private Dialogue currentDialogue;

    void Start () {
        interlocutor = GameObject.Find("Interlocutor").GetComponent<Image>();
        DialogueText = GameObject.Find("DialogueText").GetComponent<Text>();
        interlocutor.enabled = true;
        interlocutor.sprite = interlocutorSprite;
        SetNextDialogue(0);
        hero = GameObject.Find("Hero");
        previousSpeed = hero.GetComponent<Hero>().speed;
        hero.GetComponent<Hero>().speed = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (currentDialogue)
        {
            currentDialogue.CheckIfHappening();
        }
    }

    public void CompletedDialogue()
    {
        SetNextDialogue(currentDialogue.order + 1);
    }

    public void SetNextDialogue(int currentOrder)
    {
        currentDialogue = getDialogueByOrder(currentOrder);
        if (!currentDialogue)
        {
            CompleteAllDialogues();

            return;
        }

        DialogueText.text = currentDialogue.Explanation;
    }

    public void CompleteAllDialogues()
    {
        hero.GetComponent<Hero>().speed = previousSpeed;
        DialogueText.text = finishDialogue;
        interlocutor.enabled = false;
        DialogueText.text = null;
        if(blur != null)
        {
            blur.SetActive(false);
        }
        GameObject.Find("TextPressZ").GetComponent<PressZToSee>().turnOnMessage();
        Destroy(gameObject);
    }


    public Dialogue getDialogueByOrder(int Order)
    {
        for (int i = 0; i < Dialogues.Count; i++)
        {
            if (Dialogues[i].order == Order)
                return Dialogues[i];
        }
        return null;
    }
}
