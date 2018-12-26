using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDialogue : Dialogue
{
    public override void CheckIfHappening()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            DialogueManager.Instance.CompletedDialogue();
    }
}
