﻿using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Runtime.DynamicDispatching;
using UnityEngine;

public interface IShootable: IWeapon
{
    int damage { set; get; }

    float speed { set; get; }

    float fireRate { set; get; }

    int magazineCapacity { set; get; }

    int ammoInMagazine { set; get; }

    int ammo { set; get; }

    void SetDamageBullet(GameObject bullet);

    void SetSpeedBullet(GameObject bullet);

    void Shoot();

    void AutoReloading();

    void UpdateAmmo();
}
