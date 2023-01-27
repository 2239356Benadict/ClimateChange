// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to trigger the audio assigned to the NPC.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAudioPlay : MonoBehaviour
{
    public AudioClip[] converseAudioClips;
    public AudioSource avatarAudioSource;


    /// <summary>
    /// Invoking different forley audio 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //randomizing the integer value
            int randomClip = Random.Range(0, converseAudioClips.Length);
            //select the audio according to the randomized integer value
            avatarAudioSource.clip = converseAudioClips[randomClip];
            avatarAudioSource.Play();
        }
    }
}
