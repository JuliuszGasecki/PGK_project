﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCollider : MonoBehaviour {

    public bool isCollided = false;
    public GameObject heroBlock;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            TutorialManager.Instance.CompletedTutorial();
            Destroy(heroBlock);
            Destroy(this);
        }
    }
}
