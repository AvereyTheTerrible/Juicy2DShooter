using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    [SerializeField]
    private AIEnemyBrain enemyBrain = null;
    [SerializeField]
    private List<AIAction> actions = null;
    [SerializeField]
    private List<AITransition> transitions = null;

    private void Awake()
    {
        if (!enemyBrain)
            enemyBrain = transform.root.GetComponentInChildren<AIEnemyBrain>();
    }

    public void UpdateState()
    {
        foreach (var action in actions)
        {
            action.TakeAction();
        }
        foreach (var transition in transitions)
        {
            bool result = false;
            foreach (var decision in transition.Decisions)
            {
                result = decision.MakeADecision();
                if (!result)
                    break;
            }
            if (result)
            {
                if (transition.PositiveResult != null)
                {
                    enemyBrain.TransitionToState(transition.PositiveResult);
                    return;
                }
            }

            else
            {
                if (transition.NegativeResult != null)
                {
                    enemyBrain.TransitionToState(transition.NegativeResult);
                    return;
                }
            }
        }
    }
}