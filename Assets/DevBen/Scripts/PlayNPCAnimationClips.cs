// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to trigger particular animation assigned to the NPC at a certain interval of time.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNPCAnimationClips : MonoBehaviour
{
    public string[] animationNames;
    public Animator characterAnimator;

    public float repeatAfterTime;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AnimationChange", 10, repeatAfterTime);
    }

    /// <summary>
    /// Method to invoke different animation in the array.
    /// </summary>
    /// <param name="waitBefore"></param>
    public void AnimationChange()
    {

        int i = Random.Range(0, animationNames.Length-1);
        //Randomised integer is assigned to array of animation names.
        string animation = animationNames[i];

        characterAnimator.Play(animation);

    }
}
