using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillGlobalDialogues : MonoBehaviour {
	void Start () {
		if(GlobalDiagloues.dialogues.Count == 0)
        {
            GlobalDiagloues.fillDialogues();
        }
	}
	
}
