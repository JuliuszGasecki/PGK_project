using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    private Text text;

    private Hero hero;
	// Use this for initialization
	void Start ()
	{
	    text = this.gameObject.GetComponent<Text>();
	    hero = GameObject.Find("Hero").GetComponent<Hero>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (!hero.isAlive())
	    {
	        text.text = "YOU ARE DEAD";
	    }
	    if (hero.drugWithdrawal <= 0)
	    {
	        text.text = "YOU ARE DEAD CUZ OF DRUG WITHDRWAL";
	    }
	    if (hero.poisoning >= 40)
	    {
	        text.text = "YOU ARE DEAD CUZ OF POSIONING";
	    }
    }


}
