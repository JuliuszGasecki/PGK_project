using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpasMusicScript : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip firstUse;
    public AudioClip shot;
    // Use this for initialization
    private bool startFlag = true;
    private bool shotFlag;

    private Inventory inv;
    void Start()
    {
        audioSource.clip = firstUse;
        inv = this.gameObject.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (inv.GetUsingWeapon().Name == "SPAS")
        {
            if (startFlag == true)
            {
                audioSource.clip = firstUse;
                audioSource.Play();
                startFlag = false;
                shotFlag = true;
            }
            if (shotFlag)
            {
                audioSource.clip = shot;
                audioSource.Play();
            }

        }

    }
}
