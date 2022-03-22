using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyRangedAttack : EnemyAttack
{
    [SerializeField]
    private UnityEvent OnShoot;

    [SerializeField]
    private UnityEvent OnStopShoot;

    public override void Attack(int damage)
    {
        if (!waitingBeforeNextAttack)
        {
            OnShoot?.Invoke();
            StartCoroutine(this.WaitBeforeAttack());
        }
    }

    protected override IEnumerator WaitBeforeAttack()
    {

        waitingBeforeNextAttack = true;
        yield return new WaitForSecondsRealtime(AttackDelay);
        waitingBeforeNextAttack = false;
        OnStopShoot?.Invoke();
    }
}