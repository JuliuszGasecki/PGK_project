using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : Tutorial {

    private bool isCurrentTutorial = false;

    public override void CheckIfHappening()
    {
        isCurrentTutorial = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isCurrentTutorial)
        {
            return;
        }
        if(collision.gameObject.tag == "Player" )
        {
            TutorialManager.Instance.CompletedTutorial();
        }
    }
}
