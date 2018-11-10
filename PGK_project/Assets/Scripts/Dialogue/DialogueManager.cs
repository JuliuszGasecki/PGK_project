using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public List<Dialogue> Dialogues = new List<Dialogue>();

    public Text DialogueText;
    public Image interlocutor;
    public Sprite interlocutorSprite;
    public string finishDialogue;

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
        interlocutor.enabled = true;
        interlocutor.sprite = interlocutorSprite;
        SetNextDialogue(0);
    }
	
	// Update is called once per frame
	void Update () {
		
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
        DialogueText.text = finishDialogue;
        interlocutor.enabled = false;
        DialogueText.enabled = false;
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
