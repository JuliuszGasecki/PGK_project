using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    int ID
    {
        set;
        get;
    }
    void UseWeapon();

    bool CanUse { get; set; }
}
