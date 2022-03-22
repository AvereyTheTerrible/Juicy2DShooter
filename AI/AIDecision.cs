using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    [SerializeField]
    protected AIActionData aIActionData;
    [SerializeField]
    protected AIMovementData aIMovementData;
    [SerializeField]
    protected AIEnemyBrain enemyBrain;

    private void Awake()
    {
        aIActionData = transform.root.GetComponentInChildren<AIActionData>();
        aIMovementData = transform.root.GetComponentInChildren<AIMovementData>();
        enemyBrain = transform.root.GetComponentInChildren<AIEnemyBrain>();
    }

    public abstract bool MakeADecision();
}