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
        // get the audio source attached to this gameobject.
        audioToPlay = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Method to play audio once the user collides with other objects with a tag name.
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        //checking the tag of other gameobject
        if(other.gameObject.tag == collidingGameObjectTag)
        {
            audioToPlay.Play();
        }
    }
}
