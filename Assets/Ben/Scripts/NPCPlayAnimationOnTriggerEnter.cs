using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPlayAnimationOnTriggerEnter : MonoBehaviour
{

    public Animator npcAnimator;
    /// <summary>
    /// Calculating distance to player on trigger enter and NPC walk towards player
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            npcAnimator.Play("Waving");

        }
    }
}
