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
            int randomClip = Random.Range(0, converseAudioClips.Length);
            avatarAudioSource.clip = converseAudioClips[randomClip];
            avatarAudioSource.Play();
            Debug.Log("Playing converse" + other.tag);
        }
    }
}
