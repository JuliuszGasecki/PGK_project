using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDialogue : MonoBehaviour {
    public GameObject Dialogue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Dialogue != null)
        {
            if (collision.tag == "Player")
            {
                Dialogue.SetActive(true);
                gameObject.GetComponent<CreateDialogue>().enabled = false;

            }
        }
    }
}
