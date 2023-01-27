// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to play the rain particle effect.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public ParticleSystem rainParticle;
    public AudioSource rainAudio;



    private void Update()
    {
        if (rainParticle.isPlaying)
        {
            rainAudio.Play();
        }
    }
    IEnumerator StatAndStopRain()
    {
        
        yield return null;
    }
}
