using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDecision : AIDecision
{
    [field: SerializeField]
    [field: Range(0.1f, 100f)]
    public float Distance { get; set; } = 5f;
    [Header("Gizmo Paramters")]
    [SerializeField]
    private Color gizmoColor;



    public override bool MakeADecision()
    {
        if (Vector3.Distance(enemyBrain.Target.transform.position, transform.position) < Distance)
        {
            if (!aIActionData.TargetSpotted)
            {
                aIActionData.TargetSpotted = true;
            }
        }

        else
        {
            aIActionData.TargetSpotted = false;
        }

        return aIActionData.TargetSpotted;
    }

    protected void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeObject == gameObject)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawWireSphere(transform.position, Distance);
            Gizmos.color = Color.white;
        }
    }
}
