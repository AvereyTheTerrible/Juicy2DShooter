using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSounds : AudioPlayer
{
    [SerializeField]
    private AudioClip hitClip, deathClip, voiceLineClip;

    public void PlayHitClip()
    {
        PlayClipWithRandomPitch(hitClip);
    }

    public void PlayDeathClip()
    {
        PlayClipWithRandomPitch(deathClip);
    }

    public void PlayVoiceClip()
    {
        PlayClipWithRandomPitch(voiceLineClip);
    }
}
