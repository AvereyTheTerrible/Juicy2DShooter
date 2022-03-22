using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    protected AIActionData aIActionData;
    protected AIMovementData aIMovementData;
    protected AIEnemyBrain enemyBrain;

    private void Awake()
    {
        aIActionData = transform.root.GetComponentInChildren<AIActionData>();
        aIMovementData = transform.root.GetComponentInChildren<AIMovementData>();
        enemyBrain = transform.root.GetComponentInChildren<AIEnemyBrain>();
    }

    public abstract void TakeAction();
}