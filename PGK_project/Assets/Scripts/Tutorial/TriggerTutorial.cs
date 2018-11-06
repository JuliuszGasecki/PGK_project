using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : Tutorial {

    private bool isCurrentTutorial = false;
    Collider2D collision;
    public override void CheckIfHappening()
    {
        isCurrentTutorial = true;
    }

    
}
