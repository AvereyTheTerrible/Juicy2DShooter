using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWanderAction : AIAction
{
    [SerializeField]
    private float minWanderDistance = 1f, maxWanderDistance = 2f;

    [SerializeField]
    private float timeToWait;

    Vector3 randomPoint;


    private void Start()
    {
        randomPoint = (Vector3)Random.insideUnitCircle * maxWanderDistance + transform.position;
    }

    public override void TakeAction()
    {

        var direction = randomPoint - transform.position;
        aIMovementData.Direction = direction.normalized;
        aIMovementData.PointOfInterest = randomPoint;
        enemyBrain.Move(aIMovementData.Direction, aIMovementData.PointOfInterest);
    }
}