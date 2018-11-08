using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugEffectCreator : MonoBehaviour
{
    public GameObject heraEffect;
    private bool isQuitting = false;
    void OnApplicationQuit()
    {
        isQuitting = true;
    }
    void OnDestroy()
    {
        if (!isQuitting)
        {
            Instantiate(heraEffect);
        }
        
    }
}
