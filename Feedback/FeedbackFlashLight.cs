using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FeedbackFlashLight : Feedback
{
    [SerializeField]
    private Light2D lightTarget = null;
    [SerializeField]
    private float lightOnTime = 0.05f, lightOffDelay = 0.02f;
    [SerializeField]
    private bool defaultState = false;

    public override void CompletePreviousFeedback()
    {
        StopAllCoroutines();
        lightTarget.enabled = defaultState;
    }

    public override void CreateFeedback()
    {
        StartCoroutine(ToggleLightCoroutine(
            lightOnTime,
            true,
            () => StartCoroutine(ToggleLightCoroutine(
                    lightOffDelay, 
                    false))));
    }

    private IEnumerator ToggleLightCoroutine(float time, bool result, Action FinishCallback = null)
    {
        yield return new WaitForSecondsRealtime(time);
        lightTarget.enabled = result;
        FinishCallback?.Invoke();
    }

}