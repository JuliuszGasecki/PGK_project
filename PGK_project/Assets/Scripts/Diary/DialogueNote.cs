using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNote : MonoBehaviour {

    public Sprite sprite;
    [TextArea(3, 10)]
    public string text;
    public int chapterNumber;
    public string nameText;
    private bool added = false;

	// Use this for initialization
	void Start () {
        if(chapterNumber == 1 && GlobalDiagloues.dialogues[nameText] == true  && added == false)
        {
            DialoguesDiary.DiaryInstance.Notes1.Add(this);
            added = true;
        }
            
        if (chapterNumber == 2 && GlobalDiagloues.dialogues[nameText] == true && added == false)
        {
            DialoguesDiary.DiaryInstance.Notes2.Add(this);
            added = true;
        }
            
        if (chapterNumber == 3 && GlobalDiagloues.dialogues[nameText] == true && added == false)
        {
            DialoguesDiary.DiaryInstance.Notes3.Add(this);
            added = true;
        }
            
    }
    private void Update()
    {
        if (chapterNumber == 1 && GlobalDiagloues.dialogues[nameText] == true && added == false)
        {
            DialoguesDiary.DiaryInstance.Notes1.Add(this);
            added = true;
        }
            
        if (chapterNumber == 2 && GlobalDiagloues.dialogues[nameText] == true && added == false)
        {
            DialoguesDiary.DiaryInstance.Notes2.Add(this);
            added = true;
        }
            
        if (chapterNumber == 3 && GlobalDiagloues.dialogues[nameText] == true && added == false)
        {
            DialoguesDiary.DiaryInstance.Notes3.Add(this);
            added = true;
        }
            
            
    }

}
