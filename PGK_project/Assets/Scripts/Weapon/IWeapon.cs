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

    string DisplayToTextAmmo();

    string Name { get; set; }

    void DeafultAmmo();

    bool alert { set; get; } //to dla enemy
}
