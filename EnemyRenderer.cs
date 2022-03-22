using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRenderer : AgentRenderer
{
    public override void FaceDirection(Vector2 pointerInput)
    {
        var direction = (Vector3)pointerInput - transform.position;
        var result = Vector3.Cross(Vector2.up, direction);
        if (result.z > 0)
            transform.root.GetComponentInChildren<Enemy>().gameObject.transform.localScale = new Vector2(-1, 1);
        else if (result.z < 0)
            transform.root.GetComponentInChildren<Enemy>().gameObject.transform.localScale = new Vector2(1, 1);
    }
}