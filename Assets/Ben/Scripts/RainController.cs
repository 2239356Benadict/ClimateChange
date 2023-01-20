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
