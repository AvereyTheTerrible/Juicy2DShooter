using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackTimeFreeze : Feedback
{
    [SerializeField]
    private float freezeTimeDelay = 0.01f, unfreezeTimeDelay = 0.02f;
    [SerializeField]
    [Range(0, 1)]
    private float timeFreezeValue = 0f;
    public override void CompletePreviousFeedback()
    {
        if (!TimeController.instance) return;
      
        TimeController.instance.ResetTimeScale();
    }

    public override void CreateFeedback()
    {
        TimeController.instance.ModifyTimeScale(timeFreezeValue, 
            freezeTimeDelay, 
            () => TimeController.instance.ModifyTimeScale(1, unfreezeTimeDelay));
    }
}