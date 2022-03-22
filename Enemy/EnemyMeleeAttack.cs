using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : EnemyAttack
{
    public override void Attack(int damage)
    {
        if (!waitingBeforeNextAttack)
        {
            var hittable = GetTarget().GetComponent<IHittable>();
            hittable?.GetHit(damage, gameObject);
            StartCoroutine(WaitBeforeAttack());
        }
    }
}