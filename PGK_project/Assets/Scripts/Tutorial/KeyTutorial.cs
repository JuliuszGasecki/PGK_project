using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTutorial : Tutorial {

    public bool frized = false;

    public List<string> Keys = new List<string>();

    public override void CheckIfHappening()
    {
        if(frized)
            Time.timeScale = 0;
        for (int i = 0; i < Keys.Count; i++)
        {
            if(Input.inputString.Contains(Keys[i]))
            {
                Keys.RemoveAt(i);
                break;
            }
        }
        if(Keys.Count ==0)
        {
            Time.timeScale = 1;
            TutorialManager.Instance.CompletedTutorial();
            Destroy(heroBlock);
        }
    }
}
