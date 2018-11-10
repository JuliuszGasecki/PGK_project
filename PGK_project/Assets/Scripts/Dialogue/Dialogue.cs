using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {


    public int order;

    [TextArea(3, 10)]
    public string Explanation;

    private void Awake()
    {
        DialogueManager.Instance.Dialogues.Add(this);
    }

    public virtual void CheckIfHappening() { }
}
