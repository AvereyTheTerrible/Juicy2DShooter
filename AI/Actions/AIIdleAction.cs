using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleAction : AIAction
{
    public override void TakeAction()
    {
        aIMovementData.Direction = Vector2.zero;
        aIMovementData.PointOfInterest = transform.position;
        enemyBrain.Move(aIMovementData.Direction, aIMovementData.PointOfInterest);
    }
}