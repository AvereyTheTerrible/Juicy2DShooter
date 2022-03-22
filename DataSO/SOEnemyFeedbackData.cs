using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/FeedbackData")]
public class SOEnemyFeedbackData : ScriptableObject
{
    [field: SerializeField]
    public GameObject ImpactPrefab { get; private set; }
    [field: SerializeField]
    public float ImpactSpawnOffset { get; private set; }
}