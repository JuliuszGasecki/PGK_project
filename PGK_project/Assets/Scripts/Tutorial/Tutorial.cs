using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public int order;

    [TextArea (3,10)]
    public string Explanation;
    public GameObject mapBlocker;

    private void Awake()
    {
        TutorialManager.Instance.Tutorials.Add(this);
    }

    public virtual void CheckIfHappening() { }
}
