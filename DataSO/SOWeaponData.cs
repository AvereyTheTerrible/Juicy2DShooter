using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/WeaponData")]
public class SOWeaponData : ScriptableObject
{
    [field: SerializeField]
    public SOBulletData BulletData { get; set; }

    [field: SerializeField]
    [field: Range(0, 2000)]
    public int AmmoCapacity { get; set; } = 100;

    [field: SerializeField]
    public WeaponType WeaponType { get; set; } = WeaponType.automatic;

    [field: SerializeField]
    [field: Range(0.01f, 1f)]
    public float WeaponDelay { get; set; } = 0.1f;

    [field: SerializeField]
    [field: Range(0.01f, 50f)]
    public float SpreadAngle { get; set; } = 10f;

    [SerializeField]
    private bool multiBulletShot = false;
    [SerializeField]
    [Range(1, 50)]
    private int bulletCount = 1;



    public int GetBulletCountToSpawn()
    {
        if (multiBulletShot)
            return bulletCount;
        return 1;
    }
}


public enum WeaponType
{
    semiAutomatic,
    automatic,
    burst
}