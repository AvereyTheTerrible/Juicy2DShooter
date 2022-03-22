using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaseAction : AIAction
{


    public override void TakeAction()
    {
        var direction = enemyBrain.Target.transform.position - transform.position;
        aIMovementData.Direction = direction.normalized;
        aIMovementData.PointOfInterest = enemyBrain.Target.transform.position;
        enemyBrain.Move(aIMovementData.Direction, aIMovementData.PointOfInterest);
    }
}