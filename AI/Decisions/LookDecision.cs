using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LookDecision : AIDecision
{
    [SerializeField]
    [Range(0, 100)]
    private float Distance = 50;
    [SerializeField]
    private LayerMask raycastMask = new LayerMask();

    [field: SerializeField]
    public UnityEvent OnHeroSpotted { get; set; }

    public override bool MakeADecision()
    {
        var direction = enemyBrain.Target.transform.position - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Distance, raycastMask);
        if (hit.collider && hit.collider.gameObject.layer == LayerMask.NameToLayer("Hero"))
        {
            OnHeroSpotted?.Invoke();
            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeObject == gameObject && enemyBrain && enemyBrain.Target)
        {
            Gizmos.color = Color.red;
            var direction = enemyBrain.Target.transform.position - transform.position;
            Gizmos.DrawRay(transform.position, direction.normalized * Distance);
        }
    }
}