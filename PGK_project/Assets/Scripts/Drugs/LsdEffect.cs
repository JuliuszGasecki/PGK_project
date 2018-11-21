using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LsdEffect : MonoBehaviour {

    Hero hero;
    DrugsTimer dt;
    Camera cam;
    private float angle = 0;
    void Start()
    {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        dt = GameObject.Find("Hero").GetComponent<DrugsTimer>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
       // DrugsStat.drugsLsdValue++;
    }

    // Update is called once per frame
    void Update()
    {
        cam.GetComponent<CameraController>().MoveSpeed = 10;
        if (!dt.lsdFlag)
        {
            Destroy(gameObject);
        }
    }
}
