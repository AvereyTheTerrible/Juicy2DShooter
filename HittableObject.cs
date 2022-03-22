using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HittableObject : MonoBehaviour, IHittable
{
    public int Health { get; set; }

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    public void GetHit(int damage, GameObject damageDealer)
    {
        Health -= damage;
        OnGetHit?.Invoke();
        if (Health <= 0)
        {
            OnDie?.Invoke();
        }
    }
}