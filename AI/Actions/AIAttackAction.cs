using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackAction : AIAction
{
    public override void TakeAction()
    {
        aIMovementData.Direction = Vector2.zero;
        aIMovementData.PointOfInterest = enemyBrain.Target.transform.position;
        enemyBrain.Move(aIMovementData.Direction, aIMovementData.PointOfInterest);
        aIActionData.Attack = true;
        enemyBrain.Attack();
    }
}