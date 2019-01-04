using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CigaretteEffect : MonoBehaviour {

    private Hero hero;

	// Use this for initialization
	void Start () {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        hero.health += 4;

	}
}
