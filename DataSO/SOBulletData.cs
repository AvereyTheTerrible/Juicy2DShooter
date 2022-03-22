using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/BulletData")]
public class SOBulletData : ScriptableObject
{
    [field: SerializeField]
    public GameObject BulletPrefab { get; set; }

    [field: SerializeField]
    [field: Range(1, 100)]
    public float BulletSpeed { get; set; }

    [field: SerializeField]
    [field: Range(1, 50)]
    public int Damage { get; set; } = 1;

    [field: SerializeField]
    [field: Range(0.1f, 100)]
    public float Friction { get; set; }

    [field: SerializeField]
    public bool Bounce { get; set; }

    [field: SerializeField]
    public bool GoThroughHittable { get; set; }

    [field: SerializeField]
    public bool IsRaycast { get; set; }

    [field: SerializeField]
    public GameObject ImpactObstaclePrefab { get; set; }

    [field: SerializeField]
    [field: Range(1f, 50)]
    public float KnockBackPower { get; set; }

    [field: SerializeField]
    [field: Range(0.01f, 1)]
    public float KnockBackTime { get; set; }
}
