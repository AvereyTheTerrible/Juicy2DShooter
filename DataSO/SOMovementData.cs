using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Agent/MovementData")]
public class SOMovementData : ScriptableObject
{
    [Range(1, 20)]
    public float maxSpeed = 7;

    [Range(0.1f, 200)]
    public float acceleration = 50, deceleration = 50;
}
