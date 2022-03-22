using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWeapon : AudioPlayer
{
    [SerializeField]
    private AudioClip shootBulletClip = null, noAmmoClip = null;

    public void PlayShootClip()
    {
        PlayClipWithRandomPitch(shootBulletClip);
    }

    public void PlayNoAmmoClip()
    {
        PlayClip(noAmmoClip);
    }
}