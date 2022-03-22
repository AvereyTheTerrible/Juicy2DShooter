using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStepAudioPlayer : AudioPlayer
{

    [SerializeField]
    private AudioClip stepClip;

    public void PlayStepClip()
    {
        PlayClipWithRandomPitch(stepClip);
    }
}