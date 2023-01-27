// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to trigger particular animation assigned to the NPC.
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
            //play the animation by providing the name as string
            npcAnimator.Play("Waving");
        }
    }
}
