﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpecialWeapon : IShootable
{
    void SetSpecialEffect(GameObject bullet);
}
