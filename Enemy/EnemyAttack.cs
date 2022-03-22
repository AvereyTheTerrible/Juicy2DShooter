using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    protected AIEnemyBrain enemyBrain;

    [field: SerializeField]
    public float AttackDelay { get; private set; } = 1;

    protected bool waitingBeforeNextAttack;

    private void Awake()
    {
        if (!enemyBrain)
            enemyBrain = GetComponent<AIEnemyBrain>();
    }

    public abstract void Attack(int damage);

    protected virtual IEnumerator WaitBeforeAttack()
    {
        waitingBeforeNextAttack = true;
        yield return new WaitForSecondsRealtime(AttackDelay);
        waitingBeforeNextAttack = false;
    }

    protected GameObject GetTarget() => enemyBrain.Target;
}