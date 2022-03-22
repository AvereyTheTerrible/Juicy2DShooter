using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackShakeCinemachineCamera : Feedback
{
    [SerializeField]
    private CinemachineVirtualCamera cinemachineCamera;

    [SerializeField]
    [Range(0, 5)]
    private float amplitude, intensity;

    [SerializeField]
    [Range(0, 1)]
    private float duration;

    private CinemachineBasicMultiChannelPerlin noise;

    private void Start()
    {
        if (!cinemachineCamera)
            cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();
        noise = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public override void CompletePreviousFeedback()
    {
        StopAllCoroutines();
        noise.m_AmplitudeGain = 0;
    }

    public override void CreateFeedback()
    {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = intensity;
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        for (float i = duration; i > 0; i -= Time.deltaTime)
        {
            noise.m_AmplitudeGain = Mathf.Lerp(0, amplitude, i / duration);
            yield return null;
        }

        noise.m_AmplitudeGain = 0;
    }
}