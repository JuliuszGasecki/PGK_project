using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNote : MonoBehaviour {

    public Sprite sprite;
    [TextArea(3, 10)]
    public string text;
    public int chapterNumber;
    public bool isActive = false;

	// Use this for initialization
	void Start () {
        if(chapterNumber == 1)
            DialoguesDiary.DiaryInstance.Notes1.Add(this);
        if (chapterNumber == 2)
            DialoguesDiary.DiaryInstance.Notes2.Add(this);
        if (chapterNumber == 3)
            DialoguesDiary.DiaryInstance.Notes3.Add(this);
        if (chapterNumber == 4)
            DialoguesDiary.DiaryInstance.Notes4.Add(this);
        if (chapterNumber == 5)
            DialoguesDiary.DiaryInstance.Notes5.Add(this);
    }
	
}
