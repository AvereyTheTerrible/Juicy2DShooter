using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyData")]
public class SOEnemyData : ScriptableObject
{
    [field: SerializeField]
    public int MaxHealth { get; private set; } = 3;
    [field: SerializeField]
    public int Damage { get; private set; } = 1;
}