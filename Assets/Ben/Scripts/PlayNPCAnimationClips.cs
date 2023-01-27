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
        string animation = animationNames[i];

        characterAnimator.Play(animation);

    }
}
