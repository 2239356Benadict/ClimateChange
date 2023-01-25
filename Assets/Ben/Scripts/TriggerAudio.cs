// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to play audio when a collider enters into the gameobject attached with this script.

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
