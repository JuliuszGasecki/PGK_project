using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugEffectCreator : MonoBehaviour
{
    public GameObject efect;
    private bool isQuitting = false;
    void OnApplicationQuit()
    {
        isQuitting = true;
    }
    void OnDestroy()
    {
        if (!isQuitting)
        {
            Instantiate(efect);
        }
        
    }
}
