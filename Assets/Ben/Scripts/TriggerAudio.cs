using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TriggerAudio : MonoBehaviour
{
    public AudioSource audioToPlay;
    public string collidingGameObjectTag;

    private void Start()
    {
        audioToPlay = gameObject.GetComponent<AudioSource>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == collidingGameObjectTag)
        {
            audioToPlay.Play();
        }
    }
}
