using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour {

    private float time;

    void Start()
    {
        time = Time.time;
    }

    void Update()
    {
        if(Time.time - time > 4)
        {
            SceneManager.LoadScene("Home");
            Inventory inv = GameObject.Find("Hero").GetComponent<Inventory>();
            inv.GetUsingWeapon().CanUse = false;
        }
    }

}
