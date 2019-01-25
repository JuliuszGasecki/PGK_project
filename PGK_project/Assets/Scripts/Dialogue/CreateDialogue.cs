using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDialogue : MonoBehaviour {
    public GameObject Dialogue;
    //text to make it global
    public string text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Dialogue != null)
        {
            if (collision.tag == "Player")
            {
                GlobalDiagloues.dialogues[text] = true;
                Dialogue.SetActive(true);
                gameObject.GetComponent<CreateDialogue>().enabled = false;

            }
        }
    }
}
