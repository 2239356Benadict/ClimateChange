// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to calculate the rotation angle of the gameobject.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourTiltDetector : MonoBehaviour
{
    public int pourThreshold = 45;
    public Transform origin;
    public GameObject streamPrefab;

    private bool isPouring;
    private Stream stream;


    private void Update()
    {
        //checking the tilted value with the threshold value provided.
        bool pourChecking = CalaculateTheBottleTiltAngle() < pourThreshold;

        if(isPouring != pourChecking)
        {
            isPouring = pourChecking;
            if (isPouring)
            {
                StartPouring();
            }
            else
            {
                StopPouring();
            }
        }
    }
    /// <summary>
    /// Method to start pouring animation
    /// </summary>
    public void StartPouring()
    {
        stream = CreateWaterStream();
        stream.BeginStream();
    }
    /// <summary>
    /// Method to stop pouring animation.
    /// </summary>
    public void StopPouring()
    {
        //ends the line render animation
        stream.End();
        stream = null;
    }

    public float CalaculateTheBottleTiltAngle()
    {
        //calculating the angle with respect to y axis
        return transform.up.y * Mathf.Rad2Deg;
    }

    /// <summary>
    /// Method to instantiate the game object prefab at the desired position.
    /// </summary>
    /// <returns></returns>
    public Stream CreateWaterStream()
    {
        // spawning the stream prefab
        GameObject stream = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        return stream.GetComponent<Stream>();
    }
}
