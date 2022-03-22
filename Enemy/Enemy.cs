using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IHittable, IAgent, IKnockBack
{
    [field: SerializeField]
    public SOEnemyData EnemyData { get; private set; }    
    [field: SerializeField]
    public SOEnemyFeedbackData EnemyFeedbackData { get; private set; }
    [field: SerializeField]
    public int Health { get; private set; } = 2;
    [field: SerializeField]
    public EnemyAttack EnemyAttack { get; private set; }

    private bool dead = false;
    
    [SerializeField]
    private AgentMovement agentMovement;

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    private void Awake()
    {
        if (!EnemyAttack)
            EnemyAttack = GetComponent<EnemyAttack>();
        if (!agentMovement)
            agentMovement = GetComponent<AgentMovement>();
    }

    private void Start()
    {
        Health = EnemyData.MaxHealth;

    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (!dead)
        {
            Health -= damage;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                dead = true;
                OnDie?.Invoke();
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }

    public void PerformAttack()
    {
        if (!dead)
            EnemyAttack.Attack(EnemyData.Damage);
    }

    public void KnockBack(Vector2 direction, float power, float duration)
    {
        if (dead)
            agentMovement.KnockBack(direction, power + 1f, duration + 0.07f);
        else
            agentMovement.KnockBack(direction, power, duration);
    }
}
